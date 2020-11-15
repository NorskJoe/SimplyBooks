import { Injectable } from '@angular/core';
import { ConstantsService } from './constants.service';
import { HttpClientService } from './http.service';
import { Observable } from 'rxjs';
import { ResultValue } from '../shared/models/result.model';
import { NationalitySelectList } from '../authors/models/author-filter.model';

@Injectable()
export class NationalityService {
	constructor(private constants: ConstantsService,
		private http: HttpClientService) { }

	selectList(): Observable<ResultValue<NationalitySelectList>> {
		const url = `${this.constants.baseApiUrl}/nationalities/select-list`;

		return this.http.get<ResultValue<NationalitySelectList>>(url);
	}
}
