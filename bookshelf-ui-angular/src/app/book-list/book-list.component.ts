import { Book } from './../book';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  books: Book[];

  constructor() { }

  ngOnInit() {
    this.getBooks();
  }

  getBooks(): void {
    this.books = [
      {
        id: 'e13f4d30-6318-4c9d-b49c-f92edc473fcf',
        title: 'Clean Code: A Handbook of Agile Software Craftsmanship',
        authors: 'Robert Martin',
        shelf: 'Read',
        own: false,
        genre: 'Computer Science> Technical',
        yearRead: 2012,
        format: 'Kindle',
        coverImage: 'https://images.gr-assets.com/books/1436202607l/3735293.jpg'
      },
      {
        id: '80fb277a-049f-44f6-9f5a-7757dd8388d9',
        title: 'Test Driven Development: By Example',
        authors: 'Kent Beck',
        shelf: 'Read',
        own: true,
        genre: 'Computer Science> Technical',
        yearRead: 2018,
        format: 'Paperback',
        coverImage: 'https://images-na.ssl-images-amazon.com/images/I/51kDbV%2BN65L._SX396_BO1,204,203,200_.jpg'
      }
    ];
  }
}
