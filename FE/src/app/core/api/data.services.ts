import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root' // Đảm bảo service được cung cấp ở root injector
})
export class DataServices {
    private readonly API_URL = 'https://localhost:5000/api/';

    constructor(private http: HttpClient) {}

    login(username: string, password: string): Observable<any> {
        const headers = new HttpHeaders({
          'Content-Type': 'application/json',
          Accept: '*/*',
        });

        const body = { username, password };

        return this.http.post(this.API_URL+"User/login", body, { headers });
    }

    public register(model: any): Observable<any> {
        return this.http.post<any>(this.API_URL + "/api/register", model);
    }

    updateClassHistory(model: any): Observable<any> {
      const url = `${this.API_URL}ClassHistory/update`;
      return this.http.post<any>(url, model, {
        headers: { 'Content-Type': 'application/json' },
      });
    }
    
    public getClassHistory(index: number, size: number): Observable<any> {
      const url = `${this.API_URL}ClassHistory/GetAll?index=${index}&size=${size}`;
      return this.http.get<any>(url);
  }
  // Gọi API để lấy danh sách bài học của lớp học
  getLessons(idClass: string): Observable<any[]> {
    const url = `${this.API_URL}lesson/getByClass?idClass=${idClass}`;
    return this.http.get<any[]>(url);
  }

  // Gọi API để thêm bài học vào lớp học
  addLesson(idClass: string, lessonData: any): Observable<any> {
    const url = `${this.API_URL}lesson/create?idClass=${idClass}`;
    const headers = new HttpHeaders({
      'Accept': '*/*',
      'Content-Type': 'application/json'
    });
    return this.http.post(url, lessonData, { headers });
  }

}
