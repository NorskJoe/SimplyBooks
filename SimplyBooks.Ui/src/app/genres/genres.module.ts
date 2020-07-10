import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenreAddComponent } from './genre-add/genre-add.component';
import { SharedModule } from '../shared/shared.module';




@NgModule({
	declarations: [
		GenreAddComponent
	],
	imports: [
		CommonModule,
		SharedModule
	],
	exports: [
		GenreAddComponent
	]
})
export class GenresModule { }
