import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.less']
})
export class AppComponent {
	currentYear = new Date().getFullYear();

	constructor(translate: TranslateService) {
		translate.setDefaultLang('en');
	}
}
