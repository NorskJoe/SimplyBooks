import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { RoutingModule } from './routing/routing.module';
import { AppComponent } from './app.component';
import { BooksModule } from './books/books.module';
import { AuthorsModule } from './authors/authors.module';
import { ConstantsService } from './services/constants.service';
import { HttpClientService } from './services/http.service';
import { SimplyBooksErrorHandler } from './services/error-handler.service';
import { ToastrModule } from 'ngx-toastr';
import { NotificationService } from './services/notification.service';
import { NavigationModule } from './navigation/navigation.module';
import { HomeModule } from './home/home.module';
import { HomeService } from './services/home.service';


@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        RoutingModule,
        BooksModule,
        AuthorsModule,
        NavigationModule,
        HttpClientModule,
        HomeModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot({ closeButton: true })
    ],
    providers: [
        ConstantsService,
        HttpClientService,
        HomeService,
        NotificationService,
        { provide: ErrorHandler, useClass: SimplyBooksErrorHandler }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
