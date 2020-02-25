import { Injectable } from '@angular/core';
import { ConstantsService } from '../../constants.service';
import { Observable } from 'rxjs';
import { RecentBooksList } from 'src/app/shared/home/models/home-page-list.model';
import { HttpClientService } from '../../http.service';
import { ResultValue } from 'src/app/shared/models/result.model';

@Injectable()
export class HomeService {
    constructor(private constants: ConstantsService,
        private http: HttpClientService) { }


    public getRecentlyRead(): Observable<ResultValue<RecentBooksList>> {
        const url = `${this.constants.baseApiUrl}/home/list-recent`;

        return this.http.get<ResultValue<RecentBooksList>>(url);
    }
}
