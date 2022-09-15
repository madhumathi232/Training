import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { DigitalBooksUIComponent } from './digital-books-ui/digital-books-ui.component';


@NgModule({
  declarations: [
    AppComponent,
    DigitalBooksUIComponent

  
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
