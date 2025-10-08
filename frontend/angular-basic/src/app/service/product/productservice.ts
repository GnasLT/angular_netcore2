import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

export interface Product {
  id: number;
  name: string;
  price: number;
}


export class ProductService {
  constructor(private http: HttpClient) {}
  
  getFeaturedProducts(): Observable<Product[]> {
    return this.http.get<Product[]>('/api/product/getall');
  }
}

