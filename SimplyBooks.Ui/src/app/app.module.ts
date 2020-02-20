import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { RoutingModule } from './routing/routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { BooksModule } from './books/books.module';
import { AuthorsModule } from './authors/authors.module';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        RoutingModule,
        SharedModule,
        BooksModule,
        AuthorsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
