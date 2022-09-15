import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../models/readermodel';

@Injectable({
  providedIn: 'root'
})
export class ReaderService {

  baseUrl = 'https://localhost:44306/api/Books';

  constructor(private http: HttpClient) { }

  //Get all books
  getAllBooks():Observable<Book[]>{
      return this.http.get<Book[]>(this.baseUrl);
  }

}
