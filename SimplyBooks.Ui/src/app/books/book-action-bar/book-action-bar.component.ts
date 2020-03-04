import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-book-action-bar',
  templateUrl: './book-action-bar.component.html',
  styleUrls: ['./book-action-bar.component.less']
})
export class BookActionBarComponent implements OnInit {

	opened = false;

	constructor() { }

	ngOnInit(): void {
	}

	openDialog() {
		this.opened = true;
	}

	close() {
		this.opened = false;
	}
}
