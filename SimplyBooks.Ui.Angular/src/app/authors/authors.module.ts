import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorComponent } from './author.component';
import { AuthorFilterComponent } from './author-filter/author-filter.component';
import { AuthorListComponent } from './author-list/author-list.component';
import { SharedModule } from '../shared/shared.module';
import { AuthorAddComponent } from './author-add/author-add.component';




@NgModule({
	declarations: [AuthorComponent, AuthorFilterComponent, AuthorListComponent, AuthorAddComponent],
	imports: [
		CommonModule,
		SharedModule
	],
	exports: [
		AuthorFilterComponent,
		AuthorListComponent,
		AuthorAddComponent
	]
})
export class AuthorsModule { }
