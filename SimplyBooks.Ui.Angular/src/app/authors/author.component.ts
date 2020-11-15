import { Component } from '@angular/core';
import { List } from '../shared/models/list.model';
import { AuthorListFilter } from './models/author-filter.model';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { NotificationService } from '../services/notification.service';
import { TranslateService } from '@ngx-translate/core';
import { AuthorService } from '../services/authors.service';
import { AuthorListCriteria } from './models/author-service.model';

@Component({
	templateUrl: './author.component.html',
	styleUrls: ['./author.component.less']
})
export class AuthorComponent extends List {

	filter: AuthorListFilter;
	data: GridDataResult;

	constructor(private authorService: AuthorService,
		private notificationService: NotificationService,
		private translateService: TranslateService) {
		super();
	}

	applyFilter(filter: AuthorListFilter) {
		this.filter = filter;

		this.load();
	}

	stateChanged() {
		this.load();
	}

	load() {
		const criteria = {
			pageSize: this.state.pageSize,
			page: this.state.page,
			authorName: this.filter.name ? this.filter.name : null,
			nationalityId: this.filter.nationalityId ? this.filter.nationalityId : null
		} as AuthorListCriteria;

		this.authorService.listAuthors(criteria).subscribe(result => {
			this.notificationService.warnings(result.warnings, this.translateService.instant('_Warning'));
			this.data = {
				data: result.value.items,
				total: result.value.total
			} as GridDataResult;
		});
	}

	clear() {
		this.data = null;
	}

}
