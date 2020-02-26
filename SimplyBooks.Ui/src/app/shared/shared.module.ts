import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GridModule } from '@progress/kendo-angular-grid';



@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        GridModule
    ],
    exports: [
        CommonModule,
        RouterModule,
        GridModule
    ]
})
export class SharedModule { }
