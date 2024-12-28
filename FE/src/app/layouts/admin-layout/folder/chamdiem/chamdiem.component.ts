import { Component, OnInit } from '@angular/core';
import { DataServices } from 'app/core/api/data.services';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-chamdiem',
  templateUrl: './chamdiem.component.html',
  styleUrls: ['./chamdiem.component.scss']
})
export class ChamdiemComponent implements OnInit {

  constructor(
    private spinnerService: NgxSpinnerService,
    private dataService: DataServices) { }


    students: any[] = [];  // Danh sách học sinh
    pageIndex: number = 0;  // Chỉ mục trang hiện tại
    pageSize: number = 10;  // Số lượng học sinh mỗi trang
    totalStudents: number = 0;  // Tổng số học sinh
    totalPages: number = 0;  // Tổng số trang
  
  
    ngOnInit(): void {
      this.loadStudents();  // Lấy danh sách học sinh khi component khởi tạo
    }
  
    // Lấy danh sách học sinh từ API với phân trang
    loadStudents(): void {
      this.dataService.getStudents(this.pageIndex, this.pageSize).subscribe((response: any) => {
        this.students = response.items;  // Lưu danh sách học sinh
        this.totalStudents = response.totalCount;  // Lưu tổng số học sinh
        this.totalPages = Math.ceil(this.totalStudents / this.pageSize);  // Tính tổng số trang
      });
    }
  
    // Xử lý khi chuyển trang
    prevPage(): void {
      if (this.pageIndex > 0) {
        this.pageIndex--;
        this.loadStudents();  // Lấy lại danh sách học sinh khi chuyển trang
      }
    }
  
    nextPage(): void {
      if (this.pageIndex < this.totalPages - 1) {
        this.pageIndex++;
        this.loadStudents();  // Lấy lại danh sách học sinh khi chuyển trang
      }
    }
  
    // Xem bài học đã nộp của học sinh
    viewSubmittedLessons(studentId: string): void {
      // Lấy danh sách bài học đã nộp của học sinh theo studentId
      this.dataService.getSubmittedLessons(studentId).subscribe((lessons: any) => {
        // Xử lý hiển thị danh sách bài đã nộp (hoặc mở popup, mở trang chi tiết, v.v)
        console.log('Danh sách bài học đã nộp của học sinh', lessons);
        // Ví dụ mở popup hiển thị danh sách bài đã nộp
      });
    }
}
