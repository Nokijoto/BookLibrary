import { Component,Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';import { HttpClient } from '@angular/common/http';
import { Book } from 'src/app/interfaces/book';
import { Author } from 'src/app/interfaces/author';


@Component({
  selector: 'app-authordetails',
  templateUrl: './authordetails.component.html',
  styleUrls: ['./authordetails.component.css']
})
export class AuthordetailsComponent {
  apiUrl: any;
  author:any;
  constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  this.apiUrl=baseUrl}

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      const authorUuid = params.get('uuid');
      if (authorUuid) {
        this.getauthorDetails(authorUuid);
      }
    });
  }
  getauthorDetails(authorUuid: string) {
    this.http
      .get(this.apiUrl + `api/Authors/GetAuthorsByUuid/${authorUuid}`)
      .subscribe((data) => {
        this.author = data;
      });
  }
}
