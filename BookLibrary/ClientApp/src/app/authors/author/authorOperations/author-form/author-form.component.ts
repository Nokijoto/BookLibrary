import { Component, Inject } from '@angular/core';
import { Author } from 'src/app/interfaces/author';
import { HttpClient } from '@angular/common/http';
import { Location } from '@angular/common';
import { NewAuthor } from 'src/app/interfaces/NewAuthor';

@Component({
  selector: 'app-author-form',
  templateUrl: './author-form.component.html',
  styleUrls: ['./author-form.component.css'],
})
export class AuthorFormComponent {
  newAuthor: NewAuthor = {
    birthDate: '',
    description: '',
    firstName: '',
    imageUrl: '',
    lastName: '',
  };
  apiUrl: any;
  Http: any;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private location: Location
  ) {
    this.apiUrl = baseUrl;
    this.Http = http;
  }

  addAuthor() {
    this.http
      .post<NewAuthor>(this.apiUrl + 'api/Authors/AddAuthor', this.newAuthor)
      .subscribe(
        (response) => {
          console.log('Author added successfully:', response);
          this.location.back();
        },
        (error) => {
          console.error('Error adding author:', error);
        }
      );
  }
}
