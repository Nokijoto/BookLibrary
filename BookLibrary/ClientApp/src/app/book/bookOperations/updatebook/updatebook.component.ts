import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Book } from 'src/app/interfaces/book';
import { NewBook } from 'src/app/interfaces/Newbook';
import { Location } from '@angular/common';
import { Input } from '@angular/core';


@Component({
  selector: 'app-updatebook',
  templateUrl: './updatebook.component.html',
  styleUrls: ['./updatebook.component.css'],
})
export class UpdatebookComponent {
  book: any;
  apiUrl: any;
  bookUuid: any;
  @Input() value: any;
  newBook: NewBook = {
    title: '',
    totalPages: 0,
    rating: 0,
    publishedDate: new Date(),
  };
  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private location: Location
  ) {
    this.apiUrl = baseUrl;

  }

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.bookUuid = params.get('uuid');
      if (this.bookUuid) {
        this.getBookDetails(this.bookUuid);
      }
    });

  }
  getBookDetails(bookUuid: string) {
    this.http
      .get(this.apiUrl + `api/Books/GetBookByUuid/${bookUuid}`)
      .subscribe((data) => {
        this.book = data;
         this.newBook.title = this.book.title;
         this.newBook.totalPages = this.book.totalPages;
         this.newBook.rating = this.book.rating;
         this.newBook.isbn = this.book.isbn;
         this.newBook.publishedDate = this.book.publishedDate;
         this.newBook.description = this.book.description;
         this.newBook.imageUrl = this.book.imageUrl;
      });

  }
  updateBook() {
    var nbook: Book = {
      id: 0,
      bookUuid: this.bookUuid,
      title: this.newBook.title,
      totalPages: this.newBook.totalPages,
      rating: this.newBook.rating,
      isbn: this.newBook.isbn,
      publishedDate: this.newBook.publishedDate,
      description: this.newBook.description,
      imageUrl: this.newBook.imageUrl,
    };
    console.log(nbook);
    this.http
      .put<Book>(this.apiUrl + `api/Books/UpdateBook/${this.bookUuid}`, nbook)
      .subscribe(
        (response) => {
          console.log('Book added successfully:', response);
          this.location.back();
        },
        (error) => {
          console.error('Error adding book:', error);
        }
      );

  }
}
