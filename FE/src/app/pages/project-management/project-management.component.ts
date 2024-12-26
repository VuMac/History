import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DataServices } from 'app/core/api/data.services';

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

  constructor(
    private httpClient: HttpClient,
    private dataService: DataServices
  ) {}

  ngOnInit(): void {
    // Tải dữ liệu bài học ở trang đầu tiên
    this.loadLessons(this.currentPage, this.pageSize);
  }

  // Tải danh sách bài học với phân trang
  loadLessons(index: number, size: number): void {
    this.dataService.getLessonsWithPagination(index, size).subscribe(
      (response) => {
        console.log('Danh sách bài học với phân trang:', response);
        this.lessons = response; // Giả sử response có trường data chứa danh sách bài học
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
}
