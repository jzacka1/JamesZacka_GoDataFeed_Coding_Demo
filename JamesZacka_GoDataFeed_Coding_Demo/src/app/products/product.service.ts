import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Product } from '../product';

@Injectable({
  providedIn: 'root'
})
//@Injectable()
export class ProductService {

  productsUrl = "api/ProductsAPI";

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productsUrl)
      .pipe(
        catchError(this.handleError<Product[]>('getProducts'))
      );
  }

  getProductsByName(event: any): Observable<Product[]> {
    var name = event.target.value;

    if (name == "") {
      return this.getProducts();
    }

    return this.http.get<Product[]>(this.productsUrl + "/GetProductsByName/" + name)
      .pipe(
        catchError(this.handleError<Product[]>('getProductsByName'))
      );
    //return this.http.get<Product[]>(this.productsUrl + "/" + name)
    //  .pipe(
    //    catchError(this.handleError<Product[]>('getProductsByName'))
    //  );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      //// TODO: better job of transforming error for user consumption
      //this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
