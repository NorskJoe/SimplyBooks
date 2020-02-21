import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/services/shared/home/home.service';
import { RecentBooksList } from './models/home-page-list.model';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

    listItems: RecentBooksList;

    constructor(private homeService: HomeService) { }

    ngOnInit(): void {
        // https://www.ag-grid.com/angular-grid/#getting-started
        this.homeService.getRecentlyRead().subscribe(result => {
            this.listItems = result;
        });
    }

}
