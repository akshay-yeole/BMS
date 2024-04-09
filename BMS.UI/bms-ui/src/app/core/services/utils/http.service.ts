import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseHttpSerrvice } from './base.http.service';

@Injectable({
  providedIn: 'root',
})
export class CommonHttpService extends BaseHttpSerrvice {
  constructor(private http: HttpClient) {
    super();
  }

  public sendGetRequest<T>(path: string): Observable<T> {
    return this.http.get<T>(path, { headers: this.getHeaders() });
  }

  public sendPostRequest<T>(path: string, data: any): Observable<T> {
    return this.http.post<T>(path, data, { headers: this.getHeaders() });
  }

  public sendPutRequest<T>(path: string, data: any): Observable<T> {
    return this.http.put<T>(path, data, { headers: this.getHeaders() });
  }

  public sendDeleteRequest<T>(path: string): Observable<T> {
    return this.http.delete<T>(path, { headers: this.getHeaders() });
  }
}
