import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GridModule } from '@progress/kendo-angular-grid';
import { TranslateModule } from '@ngx-translate/core';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { FormsModule } from '@angular/forms';
import { DialogsModule } from '@progress/kendo-angular-dialog';
import { TooltipModule } from '@progress/kendo-angular-tooltip';
import { NgxStarsModule, NgxStarsComponent } from 'ngx-stars';
import { StarRatingModule, StarRatingComponent } from 'angular-star-rating';

@NgModule({
	imports: [
		CommonModule,
		RouterModule,
		GridModule,
		TranslateModule,
		DropDownsModule,
		DateInputsModule,
		FormsModule,
		DialogsModule,
		TooltipModule,
		NgxStarsModule,
		StarRatingModule
	],
	exports: [
		// Modules
		CommonModule,
		RouterModule,
		GridModule,
		TranslateModule,
		DropDownsModule,
		DateInputsModule,
		FormsModule,
		DialogsModule,
		TooltipModule,
		// Components
		NgxStarsComponent,
		StarRatingComponent
	]
})
export class SharedModule { }
