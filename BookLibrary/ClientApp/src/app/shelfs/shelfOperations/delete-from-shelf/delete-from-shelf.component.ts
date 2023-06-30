import { Component, Inject, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { NewBookShelves } from 'src/app/interfaces/new-book-shelves';

@Component({
  selector: 'app-delete-from-shelf',
  templateUrl: './delete-from-shelf.component.html',
  styleUrls: ['./delete-from-shelf.component.css'],
})
export class DeleteFromShelfComponent {
  @Input() bookValue: any;
  @Input() shelfValue: any;
  api: any;
  BookToShelve: NewBookShelves = {
    BookUuid: '',
    ShelveUuid: '',
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.api = baseUrl;
  }

  deleteBookFromShelve() {
        this.BookToShelve.BookUuid = this.bookValue;
        this.BookToShelve.ShelveUuid = this.shelfValue;
    this.http
      .post<NewBookShelves>(
        this.api + 'api/Books/UnBindBookWithShelves',
        this.BookToShelve
      )
      .subscribe(
        (response) => {
          console.log('Book Deleted from Shelve successfully: ', response);
          window.location.reload();
        },
        (error) => {
          console.error('Error Deleting book from Shelve: ', error);
        }
      );
  }
}
