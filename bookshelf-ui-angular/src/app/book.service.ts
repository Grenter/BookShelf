import { Book } from './book';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

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
        catchError(this.handleError(`Delete bookId=${bookId}`, false))
      );
  }

  resetBooks(): Observable<boolean> {
    return this.http.get<boolean>('https://uhguay2qye.execute-api.eu-west-2.amazonaws.com/Books/reset', httpOptions);
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(operation);
      console.error(error);
      return of(result as T);
    };
  }
}
