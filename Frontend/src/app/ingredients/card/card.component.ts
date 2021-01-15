import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IngredientService } from 'src/app/ingredient.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  constructor(private ingredientService: IngredientService) { }
  @Input() name: string;
  @Input() amount: number;
  @Output() successfulPost = new EventEmitter();

  ngOnInit(): void {
  }

  onSubmit(f: NgForm) {
    this.increaseIngredientInventory(f.value.amountToAdd);
    f.resetForm();
  }
  increaseIngredientInventory(amount: number){
    if(amount < 1)
      return;
    this.ingredientService.increaseIngredientInventory(this.name, amount)
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
