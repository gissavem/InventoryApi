import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IngredientService } from '../ingredient.service';
import { Inventory } from '../inventory';


@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.scss']
})
export class IngredientsComponent implements OnInit {

  constructor(private ingredientService: IngredientService) { }
  inventory$: Observable<Inventory>;

  ngOnInit(): void {
    this.inventory$ = this.ingredientService.getCurrentInventory();
  }

}
