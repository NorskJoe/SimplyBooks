import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationComponent } from './navigation/navigation.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';



@NgModule({
    declarations: [NavigationComponent, HomeComponent],
    imports: [
        CommonModule,
        RouterModule
    ],
    exports: [
        NavigationComponent
    ]
})
export class SharedModule { }
