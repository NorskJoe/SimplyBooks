import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

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
import { AuthorService } from './services/authors.service';
import { GenreService } from './services/genres.service';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { FormsModule } from '@angular/forms';
import { BookService } from './services/books.service';



export function HttpLoaderFactory(http: HttpClient) {
	return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

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
		ToastrModule.forRoot({ closeButton: true }),
		TranslateModule.forRoot({
			loader: {
				provide: TranslateLoader,
				useFactory: HttpLoaderFactory,
				deps: [HttpClient]
			}
		})
	],
	providers: [
		ConstantsService,
		HttpClientService,
		HomeService,
		NotificationService,
		AuthorService,
		GenreService,
		BookService,
		{ provide: ErrorHandler, useClass: SimplyBooksErrorHandler }
	],
	bootstrap: [AppComponent],
	exports: [
		TranslateModule
	]
})
export class AppModule { }
