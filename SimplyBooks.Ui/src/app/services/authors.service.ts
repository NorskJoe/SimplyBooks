import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClientService } from './http.service';
import { Observable } from 'rxjs';
import { ResultValue } from '../shared/models/result.model';
import { AuthorSelectList } from '../books/book-filter/models/book-filter.model';

@Injectable()
export class AuthorService {
	constructor(private constants: ConstantsService,
		private http: HttpClientService) { }

	selectList(): Observable<ResultValue<AuthorSelectList>> {
		const url = `${this.constants.baseApiUrl}/authors/select-list`;

		return this.http.get<ResultValue<AuthorSelectList>>(url);
	}
}
