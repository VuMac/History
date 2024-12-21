// src/app/services/api.service.ts

import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

// Định nghĩa interface cho ClassHistory (nên đặt ở file riêng nếu cần)
export interface ClassHistory {
  name: string;
  description: string; // Hoặc kiểu Date nếu bạn muốn
  // Thêm các thuộc tính khác nếu cần
}

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:5000/api'; // Thay bằng URL API thực tế

  constructor(private http: HttpClient) { }

  /**
   * Lấy danh sách lịch sử lớp học với phân trang
   * @param pageIndex Chỉ số trang (0-based)
   * @param pageSize Số lượng mục trên mỗi trang
   * @returns Observable chứa danh sách ClassHistory
   */
  getListClass(pageIndex: number, pageSize: number): Observable<ClassHistory[]> {
    const url = `${this.baseUrl}/ClassHistory/GetAll`; // Thay đổi endpoint theo API của bạn

    // Tạo các tham số truy vấn (query parameters) nếu API yêu cầu
    let params = new HttpParams()
      .set('index', pageIndex.toString())
      .set('size', pageSize.toString());

    return this.http.get<ClassHistory[]>(url, { params })
      .pipe(
        catchError(this.handleError) // Xử lý lỗi
      );
  }

  /**
   * Xử lý lỗi từ HttpClient
   * @param error Lỗi Http
   * @returns Observable với thông báo lỗi
   */
  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Lỗi phía client hoặc mạng
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Lỗi phía server
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    // Bạn có thể thêm logic logging ở đây
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
