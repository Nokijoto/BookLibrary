import { Component, Inject } from '@angular/core';
import { Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Shelf } from 'src/app/interfaces/shelve';
@Component({
  selector: 'app-deleteshelf',
  templateUrl: './deleteshelf.component.html',
  styleUrls: ['./deleteshelf.component.css'],
})
export class DeleteshelfComponent {
  @Input() value: any;
  api: any;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.api = baseUrl;
  }

  deleteShelf() {
    const apiUrl = this.api + 'api/Shelves/DeleteShelvesGuuid';
    const url = `${apiUrl}/${this.value}`;
    console.log(url);
    this.http.delete(url).subscribe(
      () => {
        console.log('Shelf deleted successfully.');
        window.location.reload();
      },
      (error) => {
        console.error('Error deleting Shelf:', error);
      }
    );
  }
}
