import { Component,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from 'src/app/interfaces/book';
import { NewBook } from 'src/app/interfaces/Newbook';
import { Location } from '@angular/common';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css'],
})
export class BookFormComponent {
  newBook: NewBook = {

    title: '',
    totalPages: 0,
    rating: 0,
    publishedDate: new Date(),
  };
  apiUrl:any;
  Http:any;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string,private location: Location) {
   this.apiUrl=baseUrl;
   this.Http=http;
  }
  addBook() {
    this.http
      .post<NewBook>(this.apiUrl + 'api/books/AddBook', this.newBook)
      .subscribe(
        (response) => {
          console.log('Book added successfully:', response);
        },
        (error) => {
          console.error('Error adding book:', error);
        }
      );
      this.location.back();
  }
}
