import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';

export class BaseHttpService {
  token = '';
  headers = {};

  constructor(private httpClient: HttpClient) {}

  public get<T>(url: string) {
    const token = localStorage.getItem('token') + '';
    const headers = { Authorization: `Bearer ${token}` };
    return this.httpClient.get<T>(url, { headers });
  }

  public post<T>(url: string, data: any) {
    const token = localStorage.getItem('token') + '';
    const headers = { Authorization: `Bearer ${token}` };
    return this.httpClient.post<T>(url, data, { headers });
  }

  public delete<T>(url: string) {
    const token = localStorage.getItem('token') + '';
    const headers = { Authorization: `Bearer ${token}` };
    return this.httpClient.delete<T>(url, { headers });
  }

  public patch<T>(url: string, data: any) {
    const token = localStorage.getItem('token') + '';
    const headers = { Authorization: `Bearer ${token}` };
    return this.httpClient.patch<T>(url, data, { headers });
  }
}
