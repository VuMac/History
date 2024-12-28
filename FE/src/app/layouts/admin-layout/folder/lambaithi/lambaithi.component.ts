import { Component, OnInit } from '@angular/core';
import { DataServices } from 'app/core/api/data.services';
import { Router } from 'express';
import { NgxSpinnerService, Spinner } from 'ngx-spinner';

@Component({
  selector: 'app-lambaithi',
  templateUrl: './lambaithi.component.html',
  styleUrls: ['./lambaithi.component.scss']
})

export class LambaithiComponent implements OnInit {

  lessons: any[] = []; // Danh sách bài học
  currentPage: number = 1; // Trang hiện tại
  pageSize: number = 5; // Số lượng bài học mỗi trang

  constructor(
    private spinnerService: NgxSpinnerService,
    private dataService: DataServices) { }

  ngOnInit(): void {
    this.loadLessons(this.currentPage, this.pageSize);
  }

  loadLessons(page: number, size: number): void {
    this.spinnerService.show();
    this.dataService.getLessonsWithPagination(page - 1, size).subscribe((response) => {
      this.spinnerService.hide();
      this.lessons = response; // Dữ liệu bài học
    });
  }
  // Chuyển sang trang tiếp theo
  nextPage(): void {
    this.currentPage++;
    this.loadLessons(this.currentPage, this.pageSize);

  }
  // Quay lại trang trước
  prevPage(): void {
    this.currentPage--;
    if (this.currentPage < 0) this.currentPage = 0
    this.loadLessons(this.currentPage, this.pageSize);
  }

  displayExamDialog: boolean = false; // Hiển thị popup
  selectedLessonTitle: string = ''; // Tiêu đề bài học hiện tại
  questions: any[] = []; // Danh sách câu hỏi

  startExam(lesson: any): void {
    this.selectedLessonTitle = lesson.title; // Lấy tiêu đề bài học
    this.dataService.getQuestionsByLessonId(lesson.id).subscribe((response) => {
      // Phân tích dữ liệu câu hỏi
      this.questions = response.map((question: any) => {
        // Chuyển description (một chuỗi JSON) thành một mảng các câu trả lời
        const answers = JSON.parse(question.description);
        return {
          id: question.id,
          title: question.title,
          answers: answers
        };
      });
      this.displayExamDialog = true; // Hiển thị popup
    });
  }


  getAnswerForQuestion(questionId: string): string | null {
    const question = this.questions.find(q => q.id === questionId);
    return question ? question.selectedAnswer : null;
  }

  submitExam(): void {
    const studentId = localStorage.getItem('userId');
    if (!studentId) {
      alert('Không thể xác định học sinh. Vui lòng đăng nhập lại.');
      return;
    }

    // Tạo danh sách submission từ các câu hỏi
    const submissions: Submission[] = this.questions.map(question => {
      if (!question.selectedAnswer) {
        alert(`Bạn chưa trả lời câu hỏi: ${question.title}`);
        throw new Error('Thiếu câu trả lời');
      }
      return {
        examId: question.id,          // ID của câu hỏi
        studentId: studentId,         // ID của học sinh
        content: question.selectedAnswer // Câu trả lời được chọn
      };
    });

    this.dataService.submitExam(submissions).subscribe(
      (response) => {
        // API trả về thành công, thông báo nộp bài thành công
        alert('Nộp bài thành công!');
        this.displayExamDialog = false; // Đóng popup sau khi nộp bài
      },
      (error) => {
        console.error('Lỗi khi nộp bài:', error);
        alert('Có lỗi xảy ra khi nộp bài. Vui lòng thử lại.');
      }
    );
  }
}
