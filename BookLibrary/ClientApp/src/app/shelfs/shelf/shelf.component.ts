import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Shelf } from 'src/app/interfaces/shelve';
import { Observable } from 'rxjs';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Book } from 'src/app/interfaces/book';
@Component({
  selector: 'app-shelf',
  templateUrl: './shelf.component.html',
  styleUrls: ['./shelf.component.css'],
})
export class ShelfComponent {
  shelfs$: Observable<any> | undefined;
  UserName: any;
  shelfs: Shelf[] = [];
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private authService: AuthorizeService
  ) {
     this.authService.getUserName().subscribe((userName) => {
       this.UserName = userName;
     });
    this.shelfs$ = http.get<Shelf[]>(baseUrl + 'api/Shelves/GetShelfsByUserName/'+this.UserName);
    this.shelfs$.subscribe(
      (result) => {
        this.shelfs = result;
      },
      (error) => console.error(error)
    );
  }

}
