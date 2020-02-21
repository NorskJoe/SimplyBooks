import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { RoutingModule } from './routing/routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { BooksModule } from './books/books.module';
import { AuthorsModule } from './authors/authors.module';
import { ConstantsService } from './services/constants.service';
import { HttpClientService } from './services/http.service';
import { SimplyBooksErrorHandler } from './services/error-handler.service';
import { HomeService } from './services/shared/home/home.service';
import { ToastrModule } from 'ngx-toastr';
import { NotificationService } from './services/notification.service';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        RoutingModule,
        SharedModule,
        BooksModule,
        AuthorsModule,
        HttpClientModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot({ closeButton: true})
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
