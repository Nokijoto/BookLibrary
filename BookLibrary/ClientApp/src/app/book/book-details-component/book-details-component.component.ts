import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-book-details-component',
  templateUrl: './book-details-component.component.html',
  styleUrls: ['./book-details-component.component.css'],
})
export class BookDetailsComponentComponent implements OnInit {
  book: any;
  apiUrl: any;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.apiUrl = baseUrl;
  }

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      const bookUuid = params.get('uuid');
      if (bookUuid) {
        this.getBookDetails(bookUuid);
      }
    });
  }
  getBookDetails(bookUuid: string) {
    this.http
      .get(this.apiUrl + `api/Books/GetBookByUuid/${bookUuid}`)
      .subscribe((data) => {
        this.book = data;
      });
  }

}
