import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

const API_URL = environment.apiUrl;

@Injectable({ providedIn: 'root' })
export class ApiService {
  constructor(private httpClient: HttpClient) {}

  get<T>(url: string): Observable<T> {
    return this.httpClient
      .get<T>(`${API_URL}/${url}`)
      .pipe(catchError((error) => this.handleError(error, url)));
  }

  post<T>(url: string, data: any): Observable<T> {
    return this.httpClient
      .post<T>(`${API_URL}/${url}`, data)
      .pipe(catchError((error) => this.handleError(error, url)));
  }

  put<T>(url: string, data: any): Observable<T> {
    return this.httpClient
      .put<T>(`${API_URL}/${url}`, data)
      .pipe(catchError((error) => this.handleError(error, url)));
  }

  update<T>(url: string, data: any): Observable<T> {
    return this.httpClient
      .put<T>(`${API_URL}/${url}`, data)
      .pipe(catchError((error) => this.handleError(error, url)));
  }

  delete<T>(url: string): Observable<T> {
    return this.httpClient
      .delete<T>(`${API_URL}/${url}`)
      .pipe(catchError((error) => this.handleError(error, url)));
  }

  handleError(error: HttpErrorResponse, url: string): Observable<never> {
    console.error('ApiService::handleError', error);
    return throwError(error);
  }
}
