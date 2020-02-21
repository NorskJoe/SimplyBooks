import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from './notification.service';

@Injectable()
export class SimplyBooksErrorHandler implements ErrorHandler {

    constructor(private injector: Injector) {
    }

    private get notificationService(): NotificationService {
      return this.injector.get(NotificationService);
  }

    handleError(error: Error | HttpErrorResponse) {
        if (error instanceof HttpErrorResponse) {
            if (!navigator.onLine) {
                this.notificationService.error('No Internet Connection.', null);
            } else {
                switch (error.status) {
                    case 404:
                        // create not found page
                    case 500:
                        if (error.error.message) {
                            this.notificationService
                                .error(error.error.message, null, { toastLife: 30000, showCloseButton: true, onActivateTick: true });
                        } else {
                            this.notificationService
                                .error('Something went wrong. Please try again.', null,
                                  { toastLife: 30000, showCloseButton: true, onActivateTick: true });
                        }
                        break;
                    default:
                        this.notificationService
                            .error('Simply Books is not available. Please try again later.', null,
                                { toastLife: 30000, showCloseButton: true, onActivateTick: true });
                }
            }
        } else {
            throw error;
        }
    }
}
