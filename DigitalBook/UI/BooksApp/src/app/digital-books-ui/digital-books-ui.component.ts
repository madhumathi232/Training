import { Component, OnInit } from '@angular/core';
import { books } from '../shared/books.model';
import { BooksService } from '../shared/books.service';

@Component({
  selector: 'app-digital-books-ui',
  templateUrl: './digital-books-ui.component.html',
  styleUrls: ['./digital-books-ui.component.css']
})
export class DigitalBooksUIComponent implements OnInit {

  constructor(bookService:BooksService) { }
  title ='cards';
  books:books[] = [];
  book : books = {
   BookId:'',
   BookName:'',
   CategoryId:'',
   Publisher:'',
   PublishedDate:'',
   Content:'',
   Active:'',
   Price:''
  }

  ngOnInit(): void {
  }
  // getAllCards() {
  //   this.bookService()
  //   .subscribe(
  //     response => { this.books = response}
  //   );
  // }

  // onSubmit(){
  //   if(this.card.id === ''){
  //     this.cardsService.addCard(this.card)
  //     .subscribe(
  //       response => {
  //         this.getAllCards();
  //         this.card = {
  //           id:'',
  //           cardNumber:'',
  //           cardholderName:'',
  //           expiryMonth:'',
  //           expiryYear:'',
  //           cvc:''
  //         };
  //       }
  //     );
  //   }
  //   else{
  //     this.updateCard(this.card);
  //   }    
  // }

  // deleteCard(id:string){
  //   this.cardsService.deleteCard(id)
  //   .subscribe(
  //     response => {
  //       this.getAllCards();
  //     }
  //   )
  // }

  // populateForm(card: Card){
  //   this.card = card;

  // }
  
  // updateCard(card: Card){
  //   this.cardsService.updateCard(card)
  //   .subscribe(
  //     response => {
  //       this.getAllCards();
  //     }
}
