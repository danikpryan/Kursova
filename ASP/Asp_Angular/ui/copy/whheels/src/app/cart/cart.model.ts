import { Product } from './../product/product.model';
import { Injectable } from "@angular/core";
@Injectable()
export class Cart {
 public lines: CartLine[] = [];
 public array:any=[];
 public itemCount: number = 0;
 public cartPrice: number = 0;

// newArray(){
//     for(let i = 0; i<=this.lines.length ; i++)
//     {
//         let tmp;
//         tmp = this.lines.find()
//     }
// }

 addLine(product: any, quantity: number = 1) {
 let line = this.lines.find(line => line.product.ProductId == product.ProductId);
 if (line != undefined) {
 line.quantity += quantity;
 } else {
 this.lines.push(new CartLine(product, quantity));
 }
 this.recalculate();
 }
 updateQuantity(product: any, quantity: number) {
 let line = this.lines.find(line => line.product.ProductId == product.ProductId);
 if (line != undefined) {
 line.quantity = Number(quantity);
 }
 this.recalculate();
 }
 removeLine(id: number) {
 let index = this.lines.findIndex(line => line.product.ProductId == id);
 this.lines.splice(index);
 this.recalculate();
 }
 clear() {
 this.lines = [];
 this.itemCount = 0;
 this.cartPrice = 0;
 }
 private recalculate() {
 this.itemCount = 0;
 this.cartPrice = 0;
 this.lines.forEach(l => {
 this.itemCount += l.quantity;
 this.cartPrice += (l.quantity * l.product.Price);
 })

}
}
export class CartLine {

 constructor(public product: any,
 public quantity: number) {}
 get lineTotal() {
 return this.quantity * this.product.Price;
 }
} 
