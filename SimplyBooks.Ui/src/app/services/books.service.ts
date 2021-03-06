import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClientService } from './http.service';
import { Observable } from 'rxjs';
import { BookListCriteria, BookList } from '../books/book-filter/models/book-service.model';
import { ResultValue, PagedResult } from '../shared/models/result.model';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class BookService {
	constructor(private constantService: ConstantsService,
		private http: HttpClientService) { }

	listBooks(criteria: BookListCriteria): Observable<ResultValue<PagedResult<BookList>>> {
		const url = `${this.constantService.baseApiUrl}/book/list`;

		let params = new HttpParams();
		params = params.set('page', criteria.page.toString());
		params = params.set('pageSize', criteria.pageSize.toString());

		if (criteria.bookTitle) {
			params = params.set('bookTitle', criteria.bookTitle);
		}

		if (criteria.authorId) {
			params = params.set('authorId', criteria.authorId.toString());
		}

		if (criteria.genreId) {
			params = params.set('genreId', criteria.genreId.toString());
		}

		if (criteria.yearRead) {
			params = params.set('yearRead', criteria.yearRead.toDateString());
		}

		if (criteria.yearPublished) {
			params = params.set('yearPublished', criteria.yearPublished.toDateString());
		}

		return this.http.get<ResultValue<PagedResult<BookList>>>(url, params);
	}
}
