import { Injectable } from '@angular/core';
import { ConstantsService } from '../../constants.service';
import { Observable } from 'rxjs';
import { HomePageList } from 'src/app/shared/home/models/home-page-list.model';
import { HttpClientService } from '../../http.service';

@Injectable()
export class HomeService {
  constructor(private constants: ConstantsService,
              private http: HttpClientService) { }


  public getRecentlyRead(): Observable<HomePageList> {
    const url = `${this.constants.baseApiUrl}/home/list-recent`;

    return this.http.get<HomePageList>(url);
  }
}
