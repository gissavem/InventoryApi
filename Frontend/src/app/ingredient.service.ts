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

  getCurrentInventory(): Observable<Inventory>{
    return this.http.get<Inventory>(this.apiUrl +"/inventory");
  }
}
