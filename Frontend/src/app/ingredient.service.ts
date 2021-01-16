import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Inventory } from './inventory';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class IngredientService {

  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiUrl;
   }
   apiUrl: string;
   endpoint = '/inventory';

  getCurrentInventory(): Observable<Inventory>{
    return this.http.get<Inventory>(this.apiUrl + this.endpoint);
  }

  increaseIngredientInventory(name: string, amount: number) {
    const body = {
      name: name,
      amount: amount
    };
    return this.http.patch(this.apiUrl + this.endpoint, body, {observe: 'response'});
  }

  massDelivery() {
    const body = {
      name: 'all',
      amount: 10
    };
    return this.http.patch(this.apiUrl + this.endpoint, body, {observe: 'response'});
  }
}
