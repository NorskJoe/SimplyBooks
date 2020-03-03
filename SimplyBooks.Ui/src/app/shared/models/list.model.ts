export class ListState {
	pageSizes: number[] | boolean = [10, 20, 40, 50, 100];
	pageSize = 10;
	skip = 0;

	get page() {
		return Math.floor(this.skip / this.pageSize) + 1;
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
}
