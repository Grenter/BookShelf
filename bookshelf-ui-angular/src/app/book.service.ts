import { Book } from './book';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>('https://uhguay2qye.execute-api.eu-west-2.amazonaws.com/Books/books', httpOptions);
  }

  deleteBook(bookId: string): Observable<boolean> {
    return this.http
      .delete<boolean>(`https://uhguay2qye.execute-api.eu-west-2.amazonaws.com/Books/books?bookId=${bookId}`, httpOptions)
      .pipe(
        tap(_ => console.log(`deleted hero id=${bookId}`)),
      );
  }
}
