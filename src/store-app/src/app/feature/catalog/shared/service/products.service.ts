import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpParams } from '@angular/common/http';
import { Product } from '../model/product';
import { ProductFilter } from '../model/product-filter';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(protected http: HttpService) {
  }
  getProducts(filter: ProductFilter): Observable<Product[]> {
    let params = new HttpParams();
    params = params.set('idBrand', filter.idBrand);
    params = params.set('idType', filter.idType);
    params = params.set('search', filter.search);

    return this.http.doGet(`${environment.endpoint}/products`, { params })
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      .pipe(map((response: any) => response as Product[]));
  }

  getProduct(id: string): Observable<Product> {
    return this.http.doGet(`${environment.endpoint}/products/${id}`)
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      .pipe(map((response: any) => response as Product));
  }
}
