import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClientService } from './http.service';
import { Observable } from 'rxjs';
import { ResultValue } from '../shared/models/result.model';
import { GenreSelectList } from '../books/book-filter/models/book-filter.model';

@Injectable()
export class GenreService {
	constructor(private constants: ConstantsService,
		private http: HttpClientService) { }

	selectList(): Observable<ResultValue<GenreSelectList>> {
		const url = `${this.constants.baseApiUrl}/genres/select-list`;

		return this.http.get<ResultValue<GenreSelectList>>(url);
	}
}
