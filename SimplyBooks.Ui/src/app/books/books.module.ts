import { NgModule } from '@angular/core';
import { BookComponent } from './book/book.component';
import { BookFilterComponent } from './book/book-filter/book-filter.component';
import { BookListComponent } from './book/book-list/book-list.component';
import { BookActionBarComponent } from './book-action-bar/book-action-bar.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
    declarations: [
        BookComponent,
        BookFilterComponent,
        BookListComponent,
        BookActionBarComponent
    ],
    imports: [
        SharedModule
    ]
})
export class BooksModule { }
