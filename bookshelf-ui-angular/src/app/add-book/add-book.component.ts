import { BookService } from './../book.service';
import { Book } from './../book';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  book: Book = new Book();

  constructor(private router: Router, private bookService: BookService) { }

  ngOnInit() {
  }

  addBook(): void {
    this.bookService.postBook(this.book)
      .subscribe(bookId => {
        if (bookId.length !== 0) {
          this.book.Id = bookId;
          this.router.navigateByUrl('/list');
        }
      });
  }
}
