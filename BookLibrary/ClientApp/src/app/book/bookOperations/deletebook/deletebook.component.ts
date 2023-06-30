import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from 'src/app/interfaces/book';

@Component({
  selector: 'app-deletebook',
  templateUrl: './deletebook.component.html',
  styleUrls: ['./deletebook.component.css'],
})
export class DeletebookComponent {
  @Input() value: any;
  api:any;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.api =baseUrl;
  }

  deleteBook() {
    const apiUrl = this.api+ 'api/Books/DeleteBookByUuid';
    const url = `${apiUrl}/${this.value}`;
    console.log(url);
    this.http.delete(url).subscribe(
      () => {
        console.log('Book deleted successfully.');
        window.location.reload();
      },
      (error) => {
        console.error('Error deleting book:', error);
      }

    );
  }
}
