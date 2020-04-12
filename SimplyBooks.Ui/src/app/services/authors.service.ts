import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClientService } from './http.service';
import { Observable } from 'rxjs';
import { ResultValue, PagedResult } from '../shared/models/result.model';
import { AuthorSelectList } from '../books/models/book-filter.model';
import { AuthorListCriteria, AuthorList } from '../authors/models/author-service.model';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class AuthorService {
	constructor(private constants: ConstantsService,
		private http: HttpClientService) { }

	selectList(): Observable<ResultValue<AuthorSelectList>> {
		const url = `${this.constants.baseApiUrl}/authors/select-list`;

		return this.http.get<ResultValue<AuthorSelectList>>(url);
	}

	listAuthors(criteria: AuthorListCriteria): Observable<ResultValue<PagedResult<AuthorList>>> {
		const url = `${this.constants.baseApiUrl}/authors/list`;

		let params = new HttpParams();

		params = params.set('page', criteria.page.toString());
		params = params.set('pageSize', criteria.pageSize.toString());

		if (criteria.authorName) {
			params = params.set('authorName', criteria.authorName);
		}

		if (criteria.nationalityId) {
			params = params.set('nationalityId', criteria.nationalityId.toString());
		}

		return this.http.get<ResultValue<PagedResult<AuthorList>>>(url, params);
	}
}
