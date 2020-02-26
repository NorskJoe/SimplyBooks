import { Component, OnInit } from '@angular/core';
import { HomePageItem } from './models/home-page-list.model';
import { HomeService } from '../services/home.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

    listItems: HomePageItem[];
    public columns: any[] = [{ field: "bookTitle" }, { field: "author" }, { field: "Rating" }];

    constructor(private homeService: HomeService) { }

    ngOnInit(): void {
        // https://www.ag-grid.com/angular-grid/#getting-started
        this.homeService.getRecentlyRead().subscribe(result => {
            // this.listItems = result;
            if (result.isSuccess) {
                this.listItems = result.value.items;
            }

        });
    }

}
