import { Component, OnInit } from '@angular/core';
import { Book, Genre } from '../models/book-add.model';
import { AuthorListItem, GenreListItem } from '../models/book-filter.model';
import { AuthorService } from 'src/app/services/authors.service';
import { GenreService } from 'src/app/services/genres.service';

@Component({
	selector: 'app-book-add',
	templateUrl: './book-add.component.html',
	styleUrls: ['./book-add.component.less']
})
export class BookAddComponent implements OnInit {

	model: Book;
	genreList: GenreListItem[];
	authorList: AuthorListItem[];
	genreId: number;
	authorId: number;
	newAuthorOpened = false;
	newGenreOpened = false;

	constructor(private authorService: AuthorService,
		private genreService: GenreService) { }

	ngOnInit(): void {

		this.model = new Book();

		this.authorService.selectList().subscribe(result => {
			this.authorList = result.value.items;
		});

		this.genreService.selectList().subscribe(result => {
			this.genreList = result.value.items;
		});
	}

	ratingClicked(rating: number) {
		this.model.rating = rating;
	}

	addBook() {
		if (this.genreId > 0) {
			this.model.genre = this.genreList.find(x => x.genreId === this.genreId);
		}

		if (this.authorId > 0) {
			this.model.author = this.authorList.find(x => x.authorId === this.authorId);
		}

		console.log(this.model);
	}

	newAuthorClicked() {
		this.newAuthorOpened = true;
	}

	newGenreClicked() {
		this.newGenreOpened = true;
	}

	addGenre(newGenre: string) {
		this.model.genre = ({
			name: newGenre,
			genreId: 0
		}) as Genre;
	}

	close() {
		this.newAuthorOpened = false;
		this.newGenreOpened = false;
	}
}
