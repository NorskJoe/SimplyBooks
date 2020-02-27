import { NgModule } from '@angular/core';
import { BookFilterComponent } from './book/book-filter/book-filter.component';
import { BookListComponent } from './book/book-list/book-list.component';
import { SharedModule } from '../shared/shared.module';
import { BookDetailComponent } from './book/book-detail/book-detail.component';
import { BookActionBarComponent } from './book/book-action-bar/book-action-bar.component';
import { BookComponent } from './book.component';



@NgModule({
    declarations: [
        BookComponent,
        BookFilterComponent,
        BookListComponent,
        BookActionBarComponent,
        BookDetailComponent
    ],
    imports: [
        SharedModule
    ]
})
export class BooksModule { }
