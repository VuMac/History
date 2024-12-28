import { Component, OnInit } from '@angular/core';
import { DataServices } from 'app/core/api/data.services';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-quanlycauhoi',
  templateUrl: './quanlycauhoi.component.html',
  styleUrls: ['./quanlycauhoi.component.scss']
})
export class QuanlycauhoiComponent implements OnInit {
  pageIndex: number = 1;
  pageSize: number = 10;
  exams: any[] = [];
  totalPages: number;

  selectedExam: any = null; // Câu hỏi đang được chọn để sửa
  displayEditDialog: boolean = false; // Trạng thái hiển thị popup sửa
  
  constructor(private dataService: DataServices,    
     private spinnerService: NgxSpinnerService,
  ) {}

  ngOnInit(): void {
    this.loadExams();
  }

  
  loadExams(): void {
    this.spinnerService.show();
    this.dataService.getExams(this.pageIndex, this.pageSize).subscribe(
      (response) => {
        // Map dữ liệu để parse description thành mảng
        this.exams = response.map((exam: any) => {
          return {
            ...exam,
            answers: JSON.parse(exam.description) // Chuyển description thành mảng
          };
        });
        this.totalPages = response.totalPages;
        this.spinnerService.hide();
      },
      (error) => {
        console.error('Có lỗi xảy ra khi tải danh sách câu hỏi:', error);
      }
    );
  }

  // Phương thức phân trang (next, previous...)
  nextPage(): void {
    if (this.pageIndex < this.totalPages) {
      this.pageIndex++;
      this.loadExams();
    }
  }

  prevPage(): void {
    if (this.pageIndex > 1) {
      this.pageIndex--;
      this.loadExams();
    }
  }

  editExam(exam: any): void {
    this.selectedExam = { ...exam }; // Tạo bản sao dữ liệu câu hỏi để chỉnh sửa
    this.displayEditDialog = true; // Hiển thị popup sửa
  }

  updateExam(): void {
    if (this.selectedExam) {
      const questionId = this.selectedExam.id;
      const title = this.selectedExam.title;
      const description = JSON.stringify(this.selectedExam.answers); // Chuyển mảng câu trả lời thành JSON string
  
      this.dataService.updateExam(questionId, title, description).subscribe(
        () => {
          this.loadExams(); // Tải lại danh sách câu hỏi sau khi cập nhật
          this.displayEditDialog = false; // Đóng popup sửa
          alert('Cập nhật câu hỏi thành công.');
        },
        (error) => {
          console.error('Có lỗi xảy ra khi cập nhật câu hỏi:', error);
          alert('Cập nhật câu hỏi thất bại.');
        }
      );
    }
  }
  
  deleteExam(id: string): void {
    if (confirm('Bạn có chắc chắn muốn xóa câu hỏi này?')) {
      this.dataService.deleteExam(id).subscribe(
        () => {
          // Tải lại danh sách sau khi xóa thành công
          this.loadExams();
          alert('Xóa câu hỏi thành công.');
        },
        (error) => {
          console.error('Có lỗi xảy ra khi xóa câu hỏi:', error);
          alert('Xóa câu hỏi thất bại.');
        }
      );
    }
  }
}
