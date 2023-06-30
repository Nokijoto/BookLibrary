import { Component,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Author } from 'src/app/interfaces/author';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css'],
})
export class AuthorComponent {
  authors$: Observable<any> | undefined;
  public authors: Author[] = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.authors$ = http.get<Author[]>(baseUrl + 'api/Authors/GetAuthors');
    this.authors$.subscribe(
      (result) => {
        this.authors = result;
      },
      (error) => console.error(error)
    );
  }
}


