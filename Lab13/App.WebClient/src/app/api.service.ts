import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl = 'http://localhost:3001/api';

  constructor(private http: HttpClient) {}

  solveLab1(inputNumber: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/lab1`, inputNumber);
  }

  solveLab2(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/lab2`, data);
  }

  solveLab3(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/lab3`, data);
  }
}
