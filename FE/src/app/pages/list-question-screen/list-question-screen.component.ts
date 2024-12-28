import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DataServices } from 'app/core/api/data.services';
import { TableModule } from 'primeng/table';
import { MessageService } from 'primeng/api'; // Nếu sử dụng PrimeNG để hiển thị thông báo
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-list-question-screen',
  templateUrl: './list-question-screen.component.html',
  styleUrls: ['./list-question-screen.component.scss']
})
export class ListQuestionScreenComponent implements OnInit {

  Math = Math; // Thêm dòng này

  displayCreateLesson: boolean = false;
  dataproduct: any = [];
  selectedOption: any;
  modelDetail: any = {};

  newLesson: any = { title: '', content: '' }; // Dữ liệu bài học mới
  selectedClass: any = null; // Lớp học đang chọn
  lessons: any[] = []; // Danh sách bài học trong lớp học
  displayLessons: boolean = false; // Kiểm tra hiển thị danh sách bài học

  // view
  displayDetail: boolean = false;
  displayCreateNew: boolean = false;

  // Phân trang
  currentPage: number = 0; // Trang hiện tại (bắt đầu từ 0)
  pageSize: number = 5; // Số lượng item mỗi trang
  totalItems: number = 0; // Tổng số item từ API

  constructor(private httpClient: HttpClient,
    private spinnerService: NgxSpinnerService,
    private messageService: MessageService, // Nếu dùng thông báo
    private dataService: DataServices) {
  }
  ngOnInit(): void {
    this.loadClassHistory(this.currentPage, this.pageSize);
  }

  // Hàm để hiển thị danh sách bài học của lớp học
  viewLessons(item: any): void {
    this.selectedClass = item; // Lưu lớp học hiện tại
    this.dataService.getLessons(item.id).subscribe(
      (response) => {
        this.lessons = response; // Lưu danh sách bài học vào `lessons`
        this.displayLessons = true; // Hiển thị danh sách bài học
      },
      (error) => {
        console.error('Có lỗi xảy ra khi lấy danh sách bài học:', error);
      }
    );
  }

  // Mở form thêm bài học
  addLesson(item: any): void {
    this.selectedClass = item; // Lưu lớp học hiện tại
    this.displayCreateLesson = true; // Mở hộp thoại thêm bài học
  }

  // Gọi API để lấy danh sách ClassHistory
  loadClassHistory(index: number, size: number): void {
    this.spinnerService.show();
    this.dataService.getClassHistory(index, size).subscribe({
      next: (data) => {
        this.dataproduct = data; // Lưu dữ liệu vào dataproduct
        this.spinnerService.hide();
      },
      error: (err) => {
        console.error('Lỗi khi gọi API:', err);
      }
    });
  }

  // Chuyển sang trang tiếp theo
  nextPage(): void {
    this.currentPage++;
    this.loadClassHistory(this.currentPage, this.pageSize);

  }

  // Quay lại trang trước
  previousPage(): void {
    this.currentPage--;
    if (this.currentPage < 0) this.currentPage = 0
    this.loadClassHistory(this.currentPage, this.pageSize);
  }

  clicktoDetail(model) {
    this.modelDetail = model;
    this.displayDetail = true;
  }

  clickToCreatNew() {
    this.displayCreateNew = true;
  }



  saveDetails(): void {
    this.dataService.updateClassHistory(this.modelDetail).subscribe({
      next: (response) => {
        console.log('Cập nhật thành công:', response);
        this.messageService.add({ severity: 'success', summary: 'Thành công', detail: 'Cập nhật lớp học thành công!' });
        this.displayDetail = false; // Đóng hộp thoại
        this.loadClassHistory(this.currentPage, this.pageSize);
      },
      error: (error) => {
        console.error('Cập nhật thất bại:', error);
        this.messageService.add({ severity: 'error', summary: 'Lỗi', detail: 'Không thể cập nhật lớp học!' });
      },
    });
  }

  // Lưu bài học
  saveLesson(): void {
    if (this.newLesson.title && this.newLesson.content) {
      const lessonData = {
        title: this.newLesson.title,
        content: this.newLesson.content
      };
      this.spinnerService.show();
      // Gọi API để thêm bài học vào lớp học thông qua service
      this.dataService.addLesson(this.selectedClass.id, lessonData).subscribe(
        (response) => {
          console.log('Thêm bài học thành công', response);
          this.spinnerService.hide();
          this.displayCreateLesson = false; // Đóng hộp thoại
          this.newLesson = { title: '', content: '' }; // Reset form
          // Bạn có thể cập nhật lại danh sách bài học hoặc thực hiện các hành động khác
        },
        (error) => {
          console.error('Có lỗi xảy ra khi thêm bài học:', error);
        }
      );
    } else {
      console.log('Thông tin bài học không đầy đủ!');
    }
  }

}
