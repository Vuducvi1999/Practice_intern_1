import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class LoginServices {
  _url = 'https://localhost:44376/api/login';
  constructor(private httpClient: HttpClient) {}
  login(info: any): Observable<any> {
    const body = JSON.stringify(info);
    const headers = { 'Content-type': 'application/json' };
    console.log(body);
    return this.httpClient.post(this._url, body, { headers });
  }
}
