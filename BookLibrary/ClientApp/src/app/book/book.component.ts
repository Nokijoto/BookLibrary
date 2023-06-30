import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../interfaces/book';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
})
export class BookComponent {
  books$: Observable<any> | undefined;
  public books: Book[] = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.books$ = http.get<Book[]>(baseUrl + 'api/Books/GetBooks');
    this.books$.subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }
}


