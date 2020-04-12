import { Component, Input, Output, EventEmitter } from '@angular/core';
import { GridDataResult, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { ListState } from 'src/app/shared/models/list.model';

@Component({
	selector: 'app-author-list',
	templateUrl: './author-list.component.html',
	styleUrls: ['./author-list.component.less']
})
export class AuthorListComponent {

	@Input() list: GridDataResult;
	@Input() state: ListState;
	@Output() stateChange = new EventEmitter<ListState>();

	constructor() { }

	dataStateChanged(state: DataStateChangeEvent) {
		this.state.pageSize = state.take;
		this.state.skip = state.skip;
		this.stateChange.emit(this.state);
	}
}
