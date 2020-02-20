import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookComponent } from './book/book.component';
import { BookFilterComponent } from './book/book-filter/book-filter.component';
import { BookListComponent } from './book/book-list/book-list.component';



@NgModule({
    declarations: [BookComponent, BookFilterComponent, BookListComponent],
    imports: [
        CommonModule
    ],
    exports: [
        BookFilterComponent,
        BookListComponent
    ]
})
export class BooksModule { }
