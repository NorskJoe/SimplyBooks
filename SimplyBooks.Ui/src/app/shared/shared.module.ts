import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationComponent } from './navigation/navigation.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { GridModule } from '@progress/kendo-angular-grid';



@NgModule({
    declarations: [NavigationComponent, HomeComponent],
    imports: [
        CommonModule,
        RouterModule,
        GridModule
    ],
    exports: [
        NavigationComponent
    ]
})
export class SharedModule { }
