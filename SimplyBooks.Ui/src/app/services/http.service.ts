import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HttpClientService {

  constructor(private http: HttpClient) { }

  private setHeaders(contentType: string = 'application/json'): HttpHeaders {
    let headers: HttpHeaders = new HttpHeaders();

    headers = headers.append('Accept', 'application/json');

    return headers;
  }

  get<T>(url: string, params: HttpParams = null): Observable<T> {
    const headers = this.setHeaders();
    return this.http.get<T>(url, { headers, params });
  }

  post<T>(url, data, contentType: string = 'application/json', params: HttpParams = null): Observable<T> {
    const headers = this.setHeaders(contentType);
    return this.http.post<T>(url, data, { headers, params });
  }

  put<T>(url, data, contentType: string = 'application/json'): Observable<T> {
    const headers = this.setHeaders(contentType);
    return this.http.put<T>(url, data, { headers });
  }

  delete<T>(url: string, params: HttpParams = null): Observable<T> {
    const headers = this.setHeaders();
    return this.http.delete<T>(url, { headers, params });
  }
}
