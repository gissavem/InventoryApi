import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MassDeliveryComponent } from './mass-delivery/mass-delivery.component';
import { IngredientsComponent } from './ingredients/ingredients.component';
import { CardComponent } from './ingredients/card/card.component';

@NgModule({
  declarations: [
    AppComponent,
    MassDeliveryComponent,
    IngredientsComponent,
    CardComponent
  ],
  imports: [
    BrowserModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
