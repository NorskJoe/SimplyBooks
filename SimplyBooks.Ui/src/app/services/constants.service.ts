import { Injectable } from '@angular/core';

@Injectable()
export class ConstantsService {
  readonly baseApiUrl: string = 'http://localhost:40001';
  readonly baseUiUrl: string = 'http://localhost:4000';
}
