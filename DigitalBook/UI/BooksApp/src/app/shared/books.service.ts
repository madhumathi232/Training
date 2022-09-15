import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { books } from './books.model';
@Injectable({
  providedIn: 'root'
})
export class BooksService {
  baseUrl = 'https://localhost:44370/api/cards';
  constructor(private http: HttpClient) { }
   getAllCards():Observable<books[]>{
      return this.http.get<books[]>(this.baseUrl);
  }
  addCard(book: books):Observable<books> {
   
    return this.http.post<books>(this.baseUrl, book);
  }

  deleteCard(id:string):Observable<books>{
    return this.http.delete<books>(this.baseUrl +'/'+id);
  }

 
}
