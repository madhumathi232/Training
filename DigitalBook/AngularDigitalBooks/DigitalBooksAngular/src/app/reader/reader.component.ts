import { Component, OnInit } from '@angular/core';
import { Book } from '../models/readermodel';
import {ReaderService} from '../service/reader.service';
@Component({
  selector: 'app-reader',
  templateUrl: './reader.component.html',
  styleUrls: ['./reader.component.css']
})
export class ReaderComponent implements OnInit {
  title = 'Search Books';
  books:Book[] = [];
  book : Book = {
    bookId: 0,
    bookName :'',
    publisher:'',
    publishedDate:'',
    price:''
  }

  constructor(private booksService : ReaderService
){
  }

  ngOnInit(): void {
    // this.getAllBooks();
  }

  getAllBooks() {
    this.booksService.getAllBooks()
    .subscribe(
      response => { this.books = response}
    );
  }
}
