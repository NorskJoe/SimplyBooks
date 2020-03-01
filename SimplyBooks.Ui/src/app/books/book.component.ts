import { Component, OnInit } from '@angular/core';
import { BookListFilter } from './book-filter/models/book-filter.model';
import { BookListCriteria } from './book-filter/models/book-service.model';
import { BookService } from '../services/books.service';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { NotificationService } from '../services/notification.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
	templateUrl: './book.component.html',
	styleUrls: ['./book.component.less']
})
export class BookComponent implements OnInit {

	filter: BookListFilter;
	data: GridDataResult;

	constructor(private bookService: BookService,
		private notificationService: NotificationService,
		private translateService: TranslateService) { }

	ngOnInit(): void {
	}

	applyFilter(filter: BookListFilter) {
		this.filter = filter;

		this.load();
	}

	load() {
		const criteria = {
			bookTitle: this.filter.title ? this.filter.title : null,
			authorId: this.filter.authorId ? this.filter.authorId : null,
			genreId: this.filter.genreId ? this.filter.genreId : null,
			yearRead: this.filter.yearRead ? this.filter.yearRead : null,
			yearPublished: this.filter.yearPublished ? this.filter.yearPublished : null
		} as BookListCriteria;

		this.bookService.listBooks(criteria).subscribe(result => {
			this.notificationService.warnings(result.warnings, this.translateService.instant('_Warning'));
			this.data = { data: result.value.items, total: result.value.items.length } as GridDataResult;
		});
	}

	clear() {
		this.data = null;
	}

}
