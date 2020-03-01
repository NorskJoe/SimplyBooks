import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';
import { Result } from '../shared/models/result.model';

export class Notification {
	public message: string;
	public title: string;
}

@Injectable()
export class NotificationService {
	public constructor(private toastr: ToastrService) {
	}

	public success(message: string, title: string = null, options: any = null) {
		if (!title) {
			title = 'Success';
		}
		this.toastr.success(message, title, options);
	}

	public error(message: string, title: string, options: any = null) {
		this.toastr.error(message, title, options);
	}

	public errors(messages: string[], title: string = null, options: any = null) {
		if (!title) {
			title = 'Error';
		}
		if (messages.length === 1) {
			this.toastr.error(messages[0], title, options);
		} else {
			let message = `<ul class='multi-message'>`;
			for (const msg of messages) {
				message += `<li>${msg}</li>`;
			}
			message += '</ul>';
			if (options === null) {
				options = { enableHtml: true };
			} else {
				options.enableHtml = true;
			}
			this.toastr.error(message, title, options);
		}
	}

	public resultErrors(result: Result, options: any = null) {
		if (!result.isSuccess) {
			this.errors(result.errors, 'Error', options);
		}
	}

	public warning(message: string, title: string, options: any = null) {
		this.toastr.warning(message, title, options);
	}

	public warnings(messages: string[], title: string, options: any = null) {
		if (messages.length > 0) {
			if (messages.length === 1) {
				this.toastr.warning(messages[0], title, options);
			} else {
				let message = `<ul class='multi-message'>`;
				for (const msg of messages) {
					message += `<li>${msg}</li>`;
				}
				message += '</ul>';
				if (options === null) {
					options = { enableHTML: true };
				} else {
					options.enableHTML = true;
				}
				this.toastr.warning(message, title, options);
			}
		}
	}

	public resultWarnings(result: Result, options: any = null) {
		if (result.hasWarnings) {
			this.warnings(result.warnings, 'Warning', options);
		}
	}
}
