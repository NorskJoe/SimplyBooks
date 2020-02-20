import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorComponent } from './author/author.component';
import { AuthorFilterComponent } from './author/author-filter/author-filter.component';
import { AuthorListComponent } from './author/author-list/author-list.component';



@NgModule({
    declarations: [AuthorComponent, AuthorFilterComponent, AuthorListComponent],
    imports: [
        CommonModule
    ],
    exports: [
        AuthorFilterComponent,
        AuthorListComponent
    ]
})
export class AuthorsModule { }
