import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
	selector: 'app-genre-add',
	templateUrl: './genre-add.component.html',
	styleUrls: ['./genre-add.component.less']
})
export class GenreAddComponent implements OnInit {

	@Output() newGenre = new EventEmitter<string>();
	genre: string;
	saved = false;

	constructor() { }

	ngOnInit(): void {
	}

	save() {
		this.newGenre.emit(this.genre);
		this.saved = true;
	}

}
