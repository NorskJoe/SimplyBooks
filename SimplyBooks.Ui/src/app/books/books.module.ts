import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { BookComponent } from './book.component';
import { BookFilterComponent } from './book-filter/book-filter.component';
import { BookListComponent } from './book-list/book-list.component';
import { BookActionBarComponent } from './book-action-bar/book-action-bar.component';
import { BookDetailComponent } from './book-detail/book-detail.component';



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
