import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import {SharedService} from 'src/app/shared.service';
import { filter} from 'rxjs/operators';
import { Cart } from "src/app/cart/cart.model";


@Component({
  selector: 'app-show-prod',
  templateUrl: './show-prod.component.html',
  styleUrls: ['./show-prod.component.css']
})
export class ShowProdComponent implements OnInit {

  constructor(private service:SharedService, private cart: Cart) { 
    this.service = service;
  }

   prod:any;
   PhotoFilePath = this.service.PhotoUrl;

  bodyText:string;
  ProductList:any=[];
  FavoriteProd:any=[];
  categoryN:number;

  public productsPerPage = 4;
  public selectedPage = 1;

  ActivateProdPage:boolean = false;
  mainWords:string;
  ModalTitle:string;
  ProductListWithoutFilter:any=[];
  ProductNameFilter:string = "";

  

  ngOnInit(): void {
    this.refreshProductList();
   // this.getFavoriteProd();
    this.bodyText = "Этот текст можно обновить";
    this.categoryN = 0;
  }

  refreshProductList(){
    //let pageIndex = (this.selectedPage - 1) * this.productsPerPage
    this.service.getM().subscribe(data=>{
      this.ProductList = data;
      this.ProductListWithoutFilter = data;
      console.log(this.ProductList);
    });
    //this.ProductList.slice(pageIndex, pageIndex+this.productsPerPage)
  }

  getByCategory(val:any){
    this.service.getByCategory(val).subscribe(data=>{
      this.ProductList = data;
    })
  }

  getFavoriteProd(){
    this.service.getIsFavorite().subscribe(data=>{
      this.ProductList = data;
    })
  }

  filterFn(){
    var ProductNameFilter = this.ProductNameFilter;
    
        this.ProductList = this.ProductListWithoutFilter.filter(function (el){
            return el.Name.toString().toLowerCase().includes(
              ProductNameFilter.toString().trim().toLowerCase()
            )
        });
  }

  changePage(newPage: number) {
    this.selectedPage = newPage;
  }
  changePageSize(newSize: number) {
    this.productsPerPage = Number(newSize);
    this.changePage(1);
    }
  /*get pageNumbers(): number[] {
    return Array(Math.ceil(this.repository
    .getProducts(this.selectedCategory).length / this.productsPerPage))
    .fill(0).map((x, i) => i + 1);
    }*/

  openModal(item, name){
    this.prod=item;
    this.ModalTitle = name;
    this.ActivateProdPage=true;
    console.log(this.ProductList);
  }

  closeModal(name ) {
    this.ModalTitle=name;
    this.ActivateProdPage=false;
    //this.refreshProductList();
  }
}
