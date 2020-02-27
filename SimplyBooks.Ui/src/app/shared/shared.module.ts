import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GridModule } from '@progress/kendo-angular-grid';
import { TranslateModule } from '@ngx-translate/core';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';



@NgModule({
	imports: [
		CommonModule,
		RouterModule,
		GridModule,
		TranslateModule,
		DropDownsModule
	],
	exports: [
		CommonModule,
		RouterModule,
		GridModule,
		TranslateModule,
		DropDownsModule
	]
})
export class SharedModule { }
