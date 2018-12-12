import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { BookService } from './../book.service';

@Component({
  selector: 'app-controls',
  templateUrl: './controls.component.html',
  styleUrls: ['./controls.component.css']
})
export class ControlsComponent implements OnInit {
  @Output() resetEvent = new EventEmitter();

  constructor(private bookService: BookService) { }

  ngOnInit() {
  }

  resetBooks(): void {
    this.bookService.resetBooks()
      .subscribe(success => {
        if (success) {
          this.resetEvent.emit();
        }
      });
  }
}
