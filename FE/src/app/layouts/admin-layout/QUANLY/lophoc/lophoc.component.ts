import { Component, OnInit } from '@angular/core';
import { ApiService,ClassHistory } from '../../../../services/api.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EditHistoryModalComponent } from './edit-history-modal/edit-history-modal.component';
import { ToastrService } from 'ngx-toastr';
import { log } from 'console';
@Component({
  selector: 'app-lophoc',
  templateUrl: './lophoc.component.html',
  styleUrls: ['./lophoc.component.scss']
})
export class LophocComponent implements OnInit {

  classHistories: ClassHistory[] = [];
  errorMessage: string = '';
  currentPage: number = 1; // Trang hiện tại
  pageSize: number = 5; // Số mục trên mỗi trang
  isLoading: boolean = false;


  constructor(private apiService: ApiService,private modalService: NgbModal,private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadClassHistories();
  }

  /**
   * Tải danh sách lịch sử lớp học từ API
   */
  loadClassHistories(): void {
    this.isLoading = true; // Bắt đầu tải dữ liệu
    this.classHistories = []; // Xóa dữ liệu cũ trước khi tải trang mới
  
    this.apiService
      .getListClass(this.currentPage - 1, this.pageSize) // Lấy dữ liệu từ API
      .subscribe({
        next: (data: ClassHistory[]) => {
          this.classHistories = data; // Gán dữ liệu mới
          this.isLoading = false; // Hoàn tất tải dữ liệu
          console.log(this.classHistories)
        },
        error: (error) => {
          this.errorMessage = 'Không thể tải danh sách lớp học.';
          console.error(error);
          this.isLoading = false; // Dừng trạng thái tải dữ liệu
        },
      });
  }
  trackById(index: number, item: ClassHistory): string {
    return item.id; // Sử dụng ID duy nhất làm khóa
  }
    /**
   * Thay đổi trang (Trước hoặc Tiếp)
   * @param direction 'prev' hoặc 'next'
   */
  changePage(direction: 'prev' | 'next'): void {
    if (direction === 'prev' && this.currentPage > 1) {
      this.currentPage--; // Giảm số trang
    } else if (direction === 'next') {
      this.currentPage++; // Tăng số trang
    }
    this.loadClassHistories(); // Tải dữ liệu cho trang mới
  }

  /**
   * Hàm để tải thêm dữ liệu (ví dụ: khi người dùng chuyển trang)
   */
  loadMore(): void {
    this.currentPage++;
    this.loadClassHistories();
  }

   /**
   * Phương thức Sửa Lịch Sử Lớp Học
   */
  editHistory(history: ClassHistory) {
    const modalRef = this.modalService.open(EditHistoryModalComponent, {
      size: 'lg', // Kích thước modal
      backdrop: true, // Đảm bảo backdrop hoạt động
      keyboard: true // Cho phép đóng modal bằng phím Escape
    });
    modalRef.componentInstance.history = { ...history }; // Truyền bản sao để tránh thay đổi trực tiếp

    modalRef.result.then((updatedHistory: ClassHistory) => {
      if (updatedHistory) {
        // Gọi API cập nhật lịch sử lớp học
        this.apiService.updateClassHistory(updatedHistory)
          .subscribe({
            next: (response) => {
              // Cập nhật danh sách classHistories
              alert('Cập nhật thành công!');
              this.refreshClassHistories();
            },
            error: (error) => {
              console.error('Failed to update history:', error);
              alert('Đã xảy ra lỗi khi cập nhật lịch sử.');
            }
          });
      }
    }).catch((reason) => {
      // Hủy bỏ modal
      console.log('Modal dismissed:', reason);
    });
  }
  private refreshClassHistories(): void {
    // Reset các tham số phân trang
    this.currentPage = 0;
    this.classHistories = [];
    this.loadClassHistories();
  }
  /**
   * Xóa lịch sử lớp học
   * @param id Guid của lớp học cần xóa
   */
  deleteHistory(id: string): void {
    if (confirm('Bạn có chắc chắn muốn xóa lớp học này?')) {
      this.apiService.deleteClassHistory(id).subscribe({
        next: () => {
          this.classHistories = this.classHistories.filter(
            (history) => history.id !== id
          );
          this.toastr.success('Xóa thành công!');
        },
        error: (error) => {
          this.toastr.error('Đã xảy ra lỗi khi xóa lớp học.');
          console.error(error);
        },
      });
    }
  }
}