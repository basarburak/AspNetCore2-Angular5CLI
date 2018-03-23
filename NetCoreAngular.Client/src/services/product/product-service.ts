import 'rxjs/add/operator/toPromise';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { ApiService } from '../api/api-service';

@Injectable()
export class ProductService {

  constructor(public api: ApiService) { }

  getProduct(): Observable<any> {
    return this.api.get('/api/Product');
  }

}
