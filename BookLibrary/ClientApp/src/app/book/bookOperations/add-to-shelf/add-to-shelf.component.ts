import { Component, Inject, Input } from '@angular/core';
import { NewBookShelves } from 'src/app/interfaces/new-book-shelves';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Shelf } from 'src/app/interfaces/shelve';
import { Observable } from 'rxjs';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Location } from '@angular/common';
@Component({
  selector: 'app-add-to-shelf',
  templateUrl: './add-to-shelf.component.html',
  styleUrls: ['./add-to-shelf.component.css'],
})
export class AddToShelfComponent {
  shelfs$: Observable<any> | undefined;
  UserName: any;
  shelfs: Shelf[] = [];
  selectedShelf: string = '';
  showConfirmation: boolean = false;
  @Input() value: any;
  api: any;
  bookUuid: any;
  BookToShelve: NewBookShelves =
    {
      BookUuid: '',
      ShelveUuid: ''
    }

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private authService: AuthorizeService,
    private location: Location,
    private route: ActivatedRoute
  ) {
    this.authService.getUserName().subscribe((userName) => {
      this.UserName = userName;
      this.api = baseUrl;
    });
    this.shelfs$ = http.get<Shelf[]>(
      baseUrl + 'api/Shelves/GetShelfsByUserName/' + this.UserName
    );
    this.shelfs$.subscribe(
      (result) => {
        this.shelfs = result;
        console.log(result);
      },
      (error) => console.error(error)
    );
  }

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.bookUuid = params.get('uuid');
    });
  }
  confirmAddBook() {
    if (this.selectedShelf) {
      this.showConfirmation = true;
    }
  }

  addBookToShelf() {
    const apiUrl = this.api + 'api/Books/BindBookWithShelves';
    const url = `${apiUrl}/${this.value}`;
    this.BookToShelve.BookUuid = this.bookUuid;
    this.BookToShelve.ShelveUuid = this.selectedShelf;
    this.showConfirmation = false;
    console.log(this.value);
    console.log(this.BookToShelve);
    this.http.post<NewBookShelves>(apiUrl, this.BookToShelve).subscribe(
      (response) => {
        console.log('Book added successfully:', response);
      },
      (error) => {
        console.error('Error adding book:', error);
      }
    );
  }

  cancelAddBook() {
    this.showConfirmation = false;
  }
}
