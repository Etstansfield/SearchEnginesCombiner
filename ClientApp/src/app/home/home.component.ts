import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  searchTerm: string;
  loading: boolean;
  hasError: boolean;
  images: string[];

  constructor(
    private http: HttpClient
  ) {

  }

  searchImages() {
    this.loading = true;
    this.images = [];
    this.hasError = false;

    this.searchImagesCall(this.searchTerm).subscribe(
      data => {
        this.images = data;
      },
      error => {
        console.error(error);
        this.loading = false;
        this.hasError = true;
      },
      () => {
        this.loading = false;
        console.log(this.images);
      }
    )

  }

  searchImagesCall(query: string): Observable<any> {
    return this.http.get(`/search/${query}`);
  }

}
