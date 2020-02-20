import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from '../shared/home/home.component';
import { BookComponent } from '../books/book/book.component';
import { AuthorComponent } from '../authors/author/author.component';


const routes: Routes = [
    { path: 'books', component: BookComponent },
    { path: 'authors', component: AuthorComponent },
    { path: 'home', component: HomeComponent },
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class RoutingModule { }
