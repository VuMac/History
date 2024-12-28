import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DataServices {
  private readonly API_URL = 'https://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Accept: '*/*',
    });

    const body = { username, password };

    return this.http.post(this.API_URL + "User/login", body, { headers });
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

  // Phương thức lấy danh sách bài học với phân trang
  getLessonsWithPagination(index: number, size: number): Observable<any> {
    const url = `${this.API_URL}lesson?index=${index}&size=${size}`;
    return this.http.get<any>(url);
  }

  updateLesson(lesson: { id: string; title: string; content: string }): Observable<any> {
    const url = `${this.API_URL}lesson/update`;
    return this.http.put(url, lesson);
  }

  createQuestion(question: any): Observable<any> {
    const url = `${this.API_URL}exam/create`;
    return this.http.post(url, question);
  }
  // Lấy câu hỏi của bài học theo ID
  getQuestionsByLessonId(lessonId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.API_URL}exam/getByLesson/${lessonId}`);
  }


  // Phương thức lấy câu hỏi theo lớp học và phân trang
  getExams(pageIndex: number, pageSize: number): Observable<any> {
    const params = new HttpParams()
      .set('pageIndex', pageIndex.toString())
      .set('pageSize', pageSize.toString());


    // Thực hiện GET request đến API
    return this.http.get(`${this.API_URL}exam/getExamsByClass`, { params });
  }

  deleteExam(id: string): Observable<any> {
    const url = `${this.API_URL}exam/${id}`;
    return this.http.delete(url);
  }



  updateExam(questionId: string, title: string, description: string): Observable<any> {
    const url = `${this.API_URL}exam/update/${questionId}`;
    const payload = {
      title,
      description,
    };
    return this.http.put(url, payload);
  }

  submitExam(submissions: any[]): Observable<any> {
    const url = `${this.API_URL}submission/submit`;
    return this.http.post(url, submissions);
  }

 

  getSubmittedLessons(studentId: string): Observable<any> {
    const url = `${this.API_URL}submissions/student/${studentId}`;
    return this.http.get<any>(url);
  } 

  // Lấy danh sách học sinh với phân trang
  getStudents(pageIndex: number, pageSize: number): Observable<any> {
    const params = new HttpParams()
      .set('pageIndex', pageIndex.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<any>(this.API_URL, { params });
  }
}
