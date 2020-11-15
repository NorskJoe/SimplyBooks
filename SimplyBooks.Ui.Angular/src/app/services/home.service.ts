import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResultValue } from 'src/app/shared/models/result.model';
import { RecentBooksList } from 'src/app/home/models/home-page-list.model';
import { ConstantsService } from './constants.service';
import { HttpClientService } from './http.service';

@Injectable()
export class HomeService {
	constructor(private constants: ConstantsService,
		private http: HttpClientService) { }


	public getRecentlyRead(): Observable<ResultValue<RecentBooksList>> {
		const url = `${this.constants.baseApiUrl}/home/list-recent`;

		return this.http.get<ResultValue<RecentBooksList>>(url);
	}
}
