import { Component, OnInit } from '@angular/core';
import { NationalityListItem } from '../models/author-filter.model';
import { NationalityService } from 'src/app/services/nationality.service';
import { Nationality } from 'src/app/books/models/book-filter.model';

@Component({
	selector: 'app-author-add',
	templateUrl: './author-add.component.html',
	styleUrls: ['./author-add.component.less']
})
export class AuthorAddComponent implements OnInit {

	nationalityList: NationalityListItem[];
	nationalityId: number;
	model: Nationality;

	constructor(private nationalityService: NationalityService) { }

	ngOnInit(): void {
		this.model = new Nationality;

		this.nationalityService.selectList().subscribe(result => {
			this.nationalityList = result.value.items;
		});
	}

	addAuthor() {
		console.log(this.model);
	}
}
