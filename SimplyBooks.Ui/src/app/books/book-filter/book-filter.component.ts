import { Component, OnInit } from '@angular/core';
import { AuthorListItem, GenreListItem, BookListFilter } from './models/book-filter.model';
import { AuthorService } from 'src/app/services/authors.service';
import { GenreService } from 'src/app/services/genres.service';

@Component({
  selector: 'app-book-filter',
  templateUrl: './book-filter.component.html',
  styleUrls: ['./book-filter.component.less']
})
export class BookFilterComponent implements OnInit {

	genreList: GenreListItem[];
	authorList: AuthorListItem[];
	model: BookListFilter;

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
  }

  applyFilter() {

  }
}
