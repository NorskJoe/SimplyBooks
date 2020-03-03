import { Component, Input, EventEmitter, Output } from '@angular/core';
import { GridDataResult, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { ListState } from 'src/app/shared/models/list.model';

@Component({
	selector: 'app-book-list',
	templateUrl: './book-list.component.html',
	styleUrls: ['./book-list.component.less']
})
export class BookListComponent {

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
