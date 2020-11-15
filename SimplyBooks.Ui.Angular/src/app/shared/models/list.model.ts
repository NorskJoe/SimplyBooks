import { SortDescriptor } from '@progress/kendo-data-query';

export class ListState {
	pageSizes: number[] | boolean = [10, 20, 40, 50, 100];
	sort?: SortDescriptor;
	pageSize = 10;
	skip = 0;

	get page() {
		return Math.floor(this.skip / this.pageSize) + 1;
	}

	get orderDirection() {
		return this.sort && this.sort ? this.sort.dir : 'asc';
	}

	get orderField() {
		return this.sort && this.sort ? this.sort.field : null;
	}
}

export class List {
	state: ListState;
	constructor() {
		this.state = new ListState();
	}
}

export class ListCriteria {
	pageSize?: number;
	page?: number;
	orderField?: string;
	orderDirection?: string;
}
