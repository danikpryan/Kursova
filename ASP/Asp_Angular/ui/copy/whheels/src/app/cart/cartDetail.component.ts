import { Component } from "@angular/core";
import { Cart } from "./cart.model";

declare var module: {
    id: string;
  }

@Component({
 moduleId: module.id,
 templateUrl: "cartDetail.component.html"
})
export class CartDetailComponent {
 constructor(public cart: Cart) { }
}