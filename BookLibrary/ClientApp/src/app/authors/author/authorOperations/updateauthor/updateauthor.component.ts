import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Author } from 'src/app/interfaces/author';
import { NewAuthor } from 'src/app/interfaces/NewAuthor';
import { Location } from '@angular/common';
import { Input } from '@angular/core';
import { __param } from 'tslib';

@Component({
  selector: 'app-updateauthor',
  templateUrl: './updateauthor.component.html',
  styleUrls: ['./updateauthor.component.css'],
})
export class UpdateauthorComponent {
  author: any;
  apiUrl: any;
  toDay:any;
  authorUuid: any;
  @Input() value: any;
  newAuthor: NewAuthor = {
    firstName: '',
    lastName: '',
    birthDate: '',
    description: '',
    imageUrl: '',
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
     setTimeout(() => {
       const today = new Date();
       const formattedDate = this.formatDate(today);
       this.newAuthor.birthDate = formattedDate;
       this.toDay=formattedDate;
     }, 0);
    this.route.paramMap.subscribe((params) => {
      this.authorUuid = params.get('uuid');
      if (this.authorUuid) {
        this.getAuthorDetails(this.authorUuid);
      }
    });
  }
  getAuthorDetails(authorUuid: string) {


    setTimeout(() => {
      const today = new Date();
      const formattedDate = this.formatDate(today);
      this.newAuthor.birthDate = formattedDate;
    }, 0);
    this.http
      .get(this.apiUrl + `api/Authors/GetAuthorsByUuid/${authorUuid}`)
      .subscribe((data) => {
        this.author = data;
        this.newAuthor.firstName = this.author.firstName;
        this.newAuthor.lastName = this.author.lastName;
        this.newAuthor.description = this.author.description;
        this.newAuthor.imageUrl = this.author.imageUrl;
        this.newAuthor.birthDate = this.toDay;
      });

  }
  updateAuthor() {
    var nAuthor: Author = {
      id: 0,
      authorUuid: this.authorUuid,
      birthDate: this.newAuthor.birthDate,
      firstName: this.newAuthor.firstName,
      lastName: this.newAuthor.lastName,
      description: this.newAuthor.description,
      imageUrl: this.newAuthor.imageUrl,
    };
    console.log(nAuthor);
    this.http
      .put<Author>(
        this.apiUrl + `api/Authors/UpdateAuthor/${this.authorUuid}`,
        nAuthor
      )
      .subscribe(
        (response) => {
          console.log('Author added successfully:', response);
          this.location.back();
        },
        (error) => {
          console.error('Author adding book:', error);
        }
      );
  }
  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2);
    const day = ('0' + date.getDate()).slice(-2);
    return `${year}-${month}-${day}`;
  }
}
