import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthorListItem, GenreListItem, BookListFilter } from './models/book-filter.model';
import { AuthorService } from 'src/app/services/authors.service';
import { GenreService } from 'src/app/services/genres.service';

@Component({
	selector: 'app-book-filter',
	templateUrl: './book-filter.component.html',
	styleUrls: ['./book-filter.component.less']
})
export class BookFilterComponent implements OnInit {

	@Output() filter = new EventEmitter<BookListFilter>();
	@Output() clear = new EventEmitter();
	genreList: GenreListItem[];
	authorList: AuthorListItem[];
	model: BookListFilter;
	yearList: number[] = [];

	constructor(private authorService: AuthorService,
		private genreService: GenreService) { }

	ngOnInit(): void {
		this.model = new BookListFilter();

		this.authorService.selectList().subscribe(result => {
			this.authorList = result.value.items;
		});

		this.genreService.selectList().subscribe(result => {
			this.genreList = result.value.items;
		});

		const startYear = 1900;
		let currentYear = new Date().getFullYear();
		while (startYear <= currentYear) {
			this.yearList.push(currentYear--);
		}
	}

	applyFilter() {
		this.filter.emit({
			title: this.model.title,
			authorId: this.model.authorId,
			genreId: this.model.genreId,
			yearRead: this.model.yearRead,
			yearPublished: this.model.yearPublished
		});
	}

	cancel() {
		this.model = new BookListFilter();
		this.clear.emit();
	}
}
