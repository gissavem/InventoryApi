import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Inventory } from '../inventory';


@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.scss']
})
export class IngredientsComponent implements OnInit {

  constructor() { }
  inventory$: Observable<Inventory>;

  ngOnInit(): void {
  }

}
