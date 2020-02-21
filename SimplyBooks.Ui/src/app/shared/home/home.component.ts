import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/services/shared/home/home.service';
import { HomePageList } from './models/home-page-list.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

  listItems: HomePageList;

  constructor(private homeService: HomeService) { }

  ngOnInit(): void {
    this.homeService.getRecentlyRead().subscribe(result => {
      this.listItems = result;
    });
  }

}
