import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorComponent } from './author.component';
import { AuthorFilterComponent } from './author-filter/author-filter.component';
import { AuthorListComponent } from './author-list/author-list.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
	declarations: [AuthorComponent, AuthorFilterComponent, AuthorListComponent],
	imports: [
		CommonModule,
		SharedModule
	],
	exports: [
		AuthorFilterComponent,
		AuthorListComponent
	]
})
export class AuthorsModule { }
