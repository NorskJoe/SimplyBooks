import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { GridModule } from '@progress/kendo-angular-grid';



@NgModule({
    declarations: [HomeComponent],
    imports: [
        CommonModule,
        RouterModule,
        GridModule
    ],
    exports: [
        CommonModule
    ]
})
export class SharedModule { }
