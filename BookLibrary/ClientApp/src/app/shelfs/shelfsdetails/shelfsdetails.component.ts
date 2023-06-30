import { Component,OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from 'src/app/interfaces/book';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-shelfsdetails',
  templateUrl: './shelfsdetails.component.html',
  styleUrls: ['./shelfsdetails.component.css'],
})
export class ShelfsdetailsComponent implements OnInit {
  books$: Observable<any> | undefined;
  public books: Book[] = [];
  apiUrl: any;
  shelfGuid: any;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute
  ) {
    this.apiUrl = baseUrl;
  }
  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      const shelfUuid = params.get('uuid');
      this.shelfGuid=shelfUuid;
      if (shelfUuid) {
        this.getBooksByShelf(shelfUuid);
      }
    });
  }
  getBooksByShelf(shelfUuid: string) {
    this.books$ = this.http.get<Book[]>(
      this.apiUrl + `api/Shelves/GetBooksFromShelvesUuid/${shelfUuid}`
    );
    this.books$.subscribe(
      (result) => {
        this.books = result;
      },
      (error) => console.error(error)
    );
  }
}
