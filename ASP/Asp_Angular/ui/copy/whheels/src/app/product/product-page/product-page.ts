import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { from } from 'rxjs';
import {SharedService} from 'src/app/shared.service';
import { filter } from 'rxjs/operators';
import { ShowProdComponent } from '../show-prod/show-prod.component';
import { Cart } from "src/app/cart/cart.model";
import {Router} from "@angular/router";
import {HomeComponent} from "src/app/home/home.compoent";

//import { products } from '../products';

@Component({
    selector: 'prod-page',
    templateUrl: './product-page.html',
    styleUrls: ['./product-page.css']
  })
  export class ProductPage implements OnInit {

  
    constructor(
      private service:SharedService,
      private cart:Cart,
      private router: Router,
      private spc:ShowProdComponent,
      private home:HomeComponent
    ) { }

   @Input()prod:any;
   ProductId: string;
   Name: string;
   Descrit:string;
   Price:string;
   Size:string;
   Color:string;
   Value:string;
   categoryId:string;
   img:string;
   img2:string;
   PhotoFilePath:string;
   PhotoFilePath1:string = this.service.PhotoUrl;
   PhotoFilePath2:string;
   MainPhoto: string;

   anotherSize:string;

   anotherInfo: any = [];
   ProdList: any = [];
   CategoryList: any =[];
   AnotherProductsList: any=[];
   SizeList: any=[];

    ngOnInit(): void {
        this.loadCategoryList();

        this.anotherProd(this.prod.Name);

        this.loadSize(this.prod.Name, this.prod.Color);
    }

    loadCategoryList(){
      this.service.getAllCategories().subscribe((data:any)=>{
        this.CategoryList=data;
        console.log(this.CategoryList);
  
        this.ProductId=this.prod.ProductId;
        this.Name=this.prod.Name;
        this.Descrit=this.prod.Descrit;
        this.Price=this.prod.Price;
        this.Size=this.prod.Size;
        this.Color=this.prod.Color;
        this.Value=this.prod.Value;
        this.categoryId=this.prod.categoryId;
        this.img=this.prod.img;
        this.img2=this.prod.img2;
        this.PhotoFilePath=this.service.PhotoUrl+this.img;
        this.PhotoFilePath2=this.service.PhotoUrl+this.img2;
        this.MainPhoto=this.service.PhotoUrl+this.img;
      });
     
    }

    //функция выгружает все размеры этого цвета
    loadSize(item, color){
      this.service.getAllSize(item, color).subscribe((data:any)=>{
        this.SizeList=data;
      })
    }

    //выгружает из бд информацию о цветах этого товара по имени
    anotherProd(val:any){
      this.service.getProd(val).subscribe(data=>{
        this.AnotherProductsList = data;
      });
    }

    //функция срабатывает при смене цвета товара меняет данные о товаре и выгружает из бд информацию о размерах этого цвета
    Change(item:any){
        this.prod = item;
        this.PhotoFilePath=this.service.PhotoUrl+item.img;
        this.loadSize(item.Name, item.Color);
        this.MainPhoto=this.service.PhotoUrl+item.img;
        this.PhotoFilePath2=this.service.PhotoUrl+item.img2;
    }

    //функция срабатывает при смене цвета
    changeSize(item:any){
      this.prod = item;
      this.PhotoFilePath=this.service.PhotoUrl+item.img;    
    }

    changePhoto(n:number){
      if(n==1){
        this.MainPhoto = this.PhotoFilePath;
      }
      else if(n==2){
        this.MainPhoto = this.PhotoFilePath2;
      }
    }

    addProductToCart(product: any) {
      this.spc.ModalTitle = "Товар додано до кошика!";
      console.log(product);
      this.cart.addLine(product);
      this.spc.closeModal("Товар додано до кошика");
      this.home.closeModal("Товар додано до кошика");
      console.log(this.cart);
      }

}