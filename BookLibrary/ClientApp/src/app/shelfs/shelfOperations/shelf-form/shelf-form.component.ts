import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Newshelve } from 'src/app/interfaces/newshelve';
import { Location } from '@angular/common';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-shelf-form',
  templateUrl: './shelf-form.component.html',
  styleUrls: ['./shelf-form.component.css'],
})
export class ShelfFormComponent {
  apiUrl: any;
  Http: any;
  UserName: any;
  newShelf: Newshelve = {
    ShelfName: '',
    CreatedByUN:''
  };
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private location: Location,
    private authService: AuthorizeService
  ) {
    this.apiUrl = baseUrl;
    this.Http = http;
    this.authService.getUserName().subscribe((userName) => {
      this.UserName = userName;
    });
  }
  addShelf() {
    var AddShelf: Newshelve = {
      ShelfName: this.newShelf.ShelfName,
      CreatedByUN: this.UserName,
    };
    console.log(AddShelf);

    this.http
      .post<Newshelve>(this.apiUrl + 'api/Shelves/AddShelves', AddShelf)
      .subscribe(
        (response) => {
          console.log('Shelf added successfully:', response);
        },
        (error) => {
          console.error('Error adding shelf:', error);
        }
      );
    this.location.back();
  }
}
