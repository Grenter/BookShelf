import { BookService } from './../book.service';
import { Book } from './../book';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[];

  constructor(private bookService: BookService) { }

  ngOnInit() {
    this.getBooks();
  }

  getBooks(): void {
    this.bookService.getBooks()
      .subscribe(books => this.books = books);
  }

  deleteBook(bookId: string): void {
    this.bookService.deleteBook(bookId)
      .subscribe(success => {
        if (success) {
          const index = this.books.indexOf(this.books.filter(i => i.Id === bookId)[0]);
          this.books.splice(index, 1);
        }
      });
  }
}
