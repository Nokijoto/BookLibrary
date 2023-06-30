import { Component, Inject } from '@angular/core';
import { Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-deleteauthor',
  templateUrl: './deleteauthor.component.html',
  styleUrls: ['./deleteauthor.component.css'],
})
export class DeleteauthorComponent {
  @Input() value: any;
  api: any;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.api = baseUrl;
  }
  deleteItem() {
    const apiUrl = this.api + 'api/Authors/DeleteAuthorGuuid';
    const url = `${apiUrl}/${this.value}`;
    console.log(url);
    this.http.delete(url).subscribe(
      () => {
        console.log('Book deleted successfully.');
      },
      (error) => {
        console.error('Error deleting book:', error);
      }
    );
    window.location.reload();
  }
}
