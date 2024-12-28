import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DataServices } from 'app/core/api/data.services';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-project-management',
  templateUrl: './project-management.component.html',
  styleUrls: ['./project-management.component.scss']
})
export class ProjectManagementComponent implements OnInit {

  lessons:any=[]; // Danh sách bài học
  currentPage = 0; // Trang hiện tại
  pageSize = 4; // Số bài học trên mỗi trang
  totalItems = 0; // Tổng số bài học
  dataproduct: any = [];
  selectedOption: any;
  modelDetail: any = {};
  
  // Hiển thị giao diện
  displayDetail: boolean = false;
  displayCreateNew: boolean = false;

  displayUpdate: boolean = false; // Hiển thị hộp thoại cập nhật
updatedLesson: any = {}; // Lưu thông tin bài học cần cập nhật

  constructor(
     private spinnerService: NgxSpinnerService,
    private httpClient: HttpClient,
    private dataService: DataServices
  ) {}

  ngOnInit(): void {
    // Tải dữ liệu bài học ở trang đầu tiên
    this.loadLessons(this.currentPage, this.pageSize);
  }

  // Tải danh sách bài học với phân trang
  loadLessons(index: number, size: number): void {
    this.spinnerService.show();
    this.dataService.getLessonsWithPagination(index, size).subscribe(
      (response) => {
        console.log('Danh sách bài học với phân trang:', response);
        this.lessons = response; // Giả sử response có trường data chứa danh sách bài học
        this.spinnerService.hide();
      },
      (error) => {
        console.error('Có lỗi xảy ra khi lấy danh sách bài học với phân trang:', error);
      }
    );
  }

  // Hiển thị chi tiết bài học
  clicktoDetail(model): void {
    this.modelDetail = model;
    this.displayDetail = true;
  }

  // Mở giao diện tạo bài học mới 
  clickToCreatNew(): void {
    this.displayCreateNew = true;
  }

  // Chuyển đến trang trước
// Chuyển sang trang tiếp theo
nextPage(): void {
  this.currentPage++;
  this.loadLessons(this.currentPage, this.pageSize);

}

// Quay lại trang trước
previousPage(): void {
  this.currentPage--;
  if(this.currentPage < 0) this.currentPage = 0
  this.loadLessons(this.currentPage, this.pageSize);
}


updateLesson(): void {
  if (!this.modelDetail.id) {
    console.error("Không tìm thấy ID bài học để cập nhật.");
    return;
  }

  this.dataService.updateLesson(this.modelDetail).subscribe(
    (response) => {
      console.log('Cập nhật bài học thành công:', response);
      this.displayDetail = false; // Ẩn dialog
      this.loadLessons(this.currentPage, this.pageSize); // Tải lại danh sách bài học
    },
    (error) => {
      console.error('Có lỗi xảy ra khi cập nhật bài học:', error);
    }
  );
}


//CÂU HỎI

displayAddQuestion: boolean = false; // Biến điều khiển dialog thêm câu hỏi
selectedLesson: any = {}; // Biến lưu bài học đang chọn

addQuestionToLesson(lesson: any): void {
  console.log('Thêm câu hỏi cho bài học:', lesson);

  this.selectedLesson = lesson;  // Gán bài học được chọn vào selectedLesson
  this.questionTitle = '';  // Reset câu hỏi
  this.answerA = '';  // Reset đáp án A
  this.answerB = '';  // Reset đáp án B
  this.answerC = '';  // Reset đáp án C
  this.answerD = '';  // Reset đáp án D
  
  this.displayAddQuestion = true;  // Mở dialog thêm câu hỏi
  this.displayAddQuestion = true; // Mở dialog để thêm câu hỏi
}

questionTitle: string = '';  // Câu hỏi
  answerA: string = '';       // Đáp án A
  answerB: string = '';       // Đáp án B
  answerC: string = '';       // Đáp án C
  answerD: string = '';       // Đáp án D

// Phương thức gửi câu hỏi
submitQuestion(): void {
  const question = {
    title: this.questionTitle,
    description: JSON.stringify([
      this.answerA,
      this.answerB,
      this.answerC,
      this.answerD
    ]),
    lessonId: this.selectedLesson.id // Gửi ID bài học từ selectedLesson
  };

  this.dataService.createQuestion(question).subscribe(
    (response) => {
      console.log('Câu hỏi đã được thêm:', response);
      this.displayAddQuestion = false; // Đóng dialog sau khi thêm thành công
    },
    (error) => {
      console.error('Có lỗi xảy ra khi thêm câu hỏi:', error);
    }
  );
}

//danh sách câu hỏi 
questions: any[] = []; // Lưu danh sách câu hỏi
selectedLessonId: string = ''; // ID bài học đang được chọn
displayQuestions: boolean = false; // Kiểm tra xem có hiển thị câu hỏi hay không 

  // Lấy danh sách câu hỏi của bài học
  viewQuestionsOfLesson(item: any): void {
    const lessonId = item.id;
    
    // Gọi API để lấy danh sách câu hỏi của bài học này
    this.dataService.getQuestionsByLessonId(lessonId).subscribe(
      (response: any) => {
        // Giả sử API trả về mảng câu hỏi, với mỗi câu hỏi có description là chuỗi JSON
        this.questions = response.map((question: any) => {
          const answers = JSON.parse(question.description); // Chuyển chuỗi JSON thành mảng đáp án
          return { 
            ...question, 
            answers: answers 
          };
        });

        this.displayQuestions = true;  // Mở dialog hiển thị câu hỏi
      },
      (error) => {
        console.error('Lỗi khi lấy câu hỏi:', error);
      }
    );
  }
  
}



