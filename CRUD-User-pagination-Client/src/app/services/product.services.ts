import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { readProduct } from './../Dtos/readProduct.dto';
import { Pagination } from './../Dtos/pagination.dto';
import { BaseHttpService } from './base.service';

// flag

@Injectable({ providedIn: 'root' })
export class ProductServices extends BaseHttpService {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  getAll(): Observable<readProduct[]> {
    const url = 'https://localhost:44376/api/products';
    return this.get<readProduct[]>(url);
  }

  getPage(index: number): Observable<Pagination> {
    const url = `https://localhost:44376/api/products/page/${index}`;
    return this.get<Pagination>(url);
  }

  getById(id: string): Observable<readProduct> {
    const url = 'https://localhost:44376/api/products/' + id;
    return this.get<readProduct>(url);
  }

  create(newProduct: FormData): Observable<any> {
    const url = 'https://localhost:44376/api/products/';
    return this.post<any>(url, newProduct);
  }

  deleteProduct(id: string): Observable<any> {
    const url = 'https://localhost:44376/api/products/' + id;
    return this.delete<any>(url);
  }

  update(id: string, updateFields: FormData): Observable<any> {
    const url = 'https://localhost:44376/api/products/' + id;
    console.log(url);
    return this.patch(url, updateFields);
  }
}
