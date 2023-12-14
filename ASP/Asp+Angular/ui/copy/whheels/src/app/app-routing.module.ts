import { teston10 } from './teston10/teston10.component';
import { OrderComponent } from './Orders/order.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {ProductComponent} from './product/product.component';//это маршрутизация
import {HomeComponent} from './home';
import { AdminComponent } from './admin';
import { from } from 'rxjs';
import { LoginComponent } from './login';
import { AuthGuard } from './_helpers';

import { CheckoutComponent } from "./cart/checkout.component";
import { CartDetailComponent } from "./cart/cartDetail.component";

const routes: Routes = [
  {
    path:'',
    component:HomeComponent
  },
  {
    path:'test',
    component:teston10
  },
  {
    path:'product',
    component:ProductComponent 
  },//пользователь увидит экран товаров
  { path: "cart", component: CartDetailComponent },
  { path: "checkout", component: CheckoutComponent },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'order',
    component: OrderComponent,
    canActivate: [AuthGuard]
  },
  { path: 'login', component: LoginComponent },
  
  //redirect to admin
  {path: '**', redirectTo: 'admin'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
