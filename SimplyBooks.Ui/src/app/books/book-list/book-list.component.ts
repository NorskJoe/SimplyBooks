import { Component, OnInit, Input } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';

@Component({
	selector: 'app-book-list',
	templateUrl: './book-list.component.html',
	styleUrls: ['./book-list.component.less']
})
export class BookListComponent {

	@Input() list: GridDataResult;

	constructor() { }

}
