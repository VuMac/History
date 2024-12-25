import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root' // Đảm bảo service được cung cấp ở root injector
})
export class DataServices {
    private readonly API_URL = 'https://localhost:5000/api/User/login';

    constructor(private http: HttpClient) {}

    login(username: string, password: string): Observable<any> {
        const headers = new HttpHeaders({
          'Content-Type': 'application/json',
          Accept: '*/*',
        });

        const body = { username, password };

        return this.http.post(this.API_URL, body, { headers });
    }

    public register(model: any): Observable<any> {
        return this.http.post<any>(this.API_URL + "/api/register", model);
    }
}
