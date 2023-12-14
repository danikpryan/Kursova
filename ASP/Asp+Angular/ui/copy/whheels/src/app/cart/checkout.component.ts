import { Product } from './../product/product.model';
import { CartLine } from './cart.model';
import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { SharedService } from "../shared.service";
import { Order } from "../_models/order";
import { HttpClient } from '@angular/common/http';
import { Cart } from "src/app/cart/cart.model";
import { Guid } from 'guid-typescript'

declare var module: {
    id: string;
}

@Component({
    moduleId: module.id,
    templateUrl: "checkout.component.html",
    styleUrls: ["checkout.component.css"]
})
export class CheckoutComponent {
    readonly APIUrl = "http://localhost:5000/api";
    orderSent: boolean = false;
    submitted: boolean = false;
    id: string;
    array: any[] = [];
    constructor(public service: SharedService, public order: Order, private cart: Cart,) { }
    submitOrder(form: NgForm) {
        this.id = Guid.create().toString();
        this.submitted = true;
        if (form.valid) {
            this.array = this.cart.lines;
            console.log(this.id);
            this.array.map(item => {

                let arr = [];
                arr.push(item.product.ProductId)
                arr.push(item.quantity)

                this.service.saveOrdersProduct(arr, this.id).subscribe(order => {
                    this.orderSent = true;
                    this.submitted = false;
                });

                // this.service.updt(arr).subscribe(order =>{
                //     this.orderSent = true;
                //     this.submitted = false;
                // })

            })

            this.array.map(item =>{
                let arr= [];
                arr.push(item.product.ProductId)
                
                

            })
            

            this.service.saveOrder(this.order, this.id).subscribe(order => {
                this.orderSent = true;
                this.submitted = false;
                console.log(this.cart.lines);
            });

        }
    }



}