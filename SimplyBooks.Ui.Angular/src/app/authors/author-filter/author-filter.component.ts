import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AuthorListFilter, NationalityListItem } from '../models/author-filter.model';
import { NationalityService } from 'src/app/services/nationality.service';

@Component({
	selector: 'app-author-filter',
	templateUrl: './author-filter.component.html',
	styleUrls: ['./author-filter.component.less']
})
export class AuthorFilterComponent implements OnInit {

	@Output() filter = new EventEmitter<AuthorListFilter>();
	@Output() clear = new EventEmitter();
	nationalityList: NationalityListItem[];
	model: AuthorListFilter;

	constructor(private nationalityService: NationalityService) { }

	ngOnInit(): void {
		this.model = new AuthorListFilter();

		this.nationalityService.selectList().subscribe(result => {
			this.nationalityList = result.value.items;
		});
	}

	applyFilter() {
		this.filter.emit({
			name: this.model.name,
			nationalityId: this.model.nationalityId
		});
	}

	cancel() {
		this.model = new AuthorListFilter();
		this.clear.emit();
	}
}
