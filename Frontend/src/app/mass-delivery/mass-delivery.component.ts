import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IngredientService } from '../ingredient.service';

@Component({
  selector: 'app-mass-delivery',
  templateUrl: './mass-delivery.component.html',
  styleUrls: ['./mass-delivery.component.scss']
})
export class MassDeliveryComponent implements OnInit {
  @Output() successfulPost = new EventEmitter();

  constructor(private ingredientService: IngredientService) { }

  ngOnInit(): void {
  }

  massDelivery(){
    console.log("mass delivery")
    this.ingredientService.massDelivery()
      .subscribe(
      (response) => {
        this.successfulPost.emit()
        return true;
      }, 
      (httpError) => {
        return false;
      });
  }

}
