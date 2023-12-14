import { Product } from './../../product/product.model';
import { OrderComponent } from './../order.component';
import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import {Guid} from 'guid-typescript';


@Component({
  selector: 'detail',
  templateUrl: './detail.component.html',
  //styleUrls: ['./add-edit-prod.component.css']
})
export class DetailComponent implements OnInit {

  constructor(private service:SharedService, private order:OrderComponent) 
  {
  }

  @Input() prod:any;
   Id: string;

   detailList:any[];
  CategoryList:any=[];
  public ProductList:any[];
  b:any[];
  ngOnInit(): void {
       this.loadCategoryList();
       this.loadDetailList();
       
  }

  loadCategoryList(){
    this.service.getAllCategories().subscribe((data:any)=>{
      this.CategoryList=data;

      this.Id=this.prod.Id;
    })
  }

    loadDetailList(){
        this.service.getDetail(this.prod.Id).subscribe(data=>{
            this.detailList=data;
            let array:any[];
            
            let arr =Array<any[]>();
            console.log(this.detailList);
            this.detailList.map(item => {
              let arrr = Array<any[]>();
              let arr =Array<any[]>();
              let i:number;
              
              arrr.push(item.price);
              arr.push(item.ProductId)

              
            
            
             this.service.getDetailProd(arr).subscribe(val=>{//дозаписать значения
              this.ProductList = val;

              
             
            });
            console.log(this.ProductList);

          })
        });
        console.log(this.ProductList);
    }

    updte(val:any){
      console.log(val);
      this.service.updt(val).subscribe(res=>{
        alert(res.toString());
        });
        console.log(val);
    }


}
