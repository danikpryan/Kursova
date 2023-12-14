import { teston10 } from './teston10/teston10.component';
import { DetailComponent } from './Orders/orderDetail/detail.component';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from "@angular/common";
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {ModalModule} from './_modal'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { ShowProdComponent } from './product/show-prod/show-prod.component';
import { AddEditProdComponent } from './product/add-edit-prod/add-edit-prod.component';
import{SharedService} from './shared.service';
import {HomeComponent} from './home';
import {AdminComponent} from './admin';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { ProductPage } from './product/product-page/product-page';
import {ContComponent} from './contacts'

import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { LoginComponent } from './login';

import { Cart } from "../app/cart/cart.model";
import { CartSummaryComponent } from "./cart/cartSummary.component";

import { CartDetailComponent } from "./cart/cartDetail.component";
import { CheckoutComponent } from "./cart/checkout.component";

import {OrderComponent} from "./Orders/order.component";

import {Order} from './_models/order';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    ProductPage,
    AppComponent,
    ProductComponent,
    ShowProdComponent,
    AddEditProdComponent,
    AdminComponent,
    HomeComponent,
    LoginComponent,
    ContComponent,
    CartSummaryComponent,
    CartDetailComponent, 
    CheckoutComponent,
    OrderComponent,
    DetailComponent,
    teston10
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule,
    NgbModule
  ],
  exports:[
     CartDetailComponent, CheckoutComponent
  ],
 providers: [
  { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    Cart,
    CartSummaryComponent,
    SharedService,
    Order,
    ShowProdComponent,
    HomeComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
