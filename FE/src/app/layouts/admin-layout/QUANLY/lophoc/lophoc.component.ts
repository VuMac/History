import { Component, OnInit } from '@angular/core';
import { ApiService,ClassHistory } from '../../../../services/api.service';

@Component({
  selector: 'app-lophoc',
  templateUrl: './lophoc.component.html',
  styleUrls: ['./lophoc.component.scss']
})
export class LophocComponent implements OnInit {

  classHistories: ClassHistory[] = [];
  errorMessage: string = '';
  pageIndex: number = 0;
  pageSize: number = 10;
  isLoading: boolean = false;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {

    this.loadClassHistories();
  }

  /**
   * Tải danh sách lịch sử lớp học từ API
   */
  loadClassHistories(): void {
  
    this.isLoading = true;
    this.apiService.getListClass(this.pageIndex, this.pageSize)
      .subscribe(
        (data: ClassHistory[]) => {
          this.classHistories = [...this.classHistories, ...data];
          this.isLoading = false;
        },
        (error: string) => {
          this.errorMessage = error;
          this.isLoading = false;
        }
      );
  }

  /**
   * Hàm để tải thêm dữ liệu (ví dụ: khi người dùng chuyển trang)
   */
  loadMore(): void {
    this.pageIndex++;
    this.loadClassHistories();
  }
}