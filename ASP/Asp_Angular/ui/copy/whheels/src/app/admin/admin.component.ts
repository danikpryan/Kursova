import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import {SharedService} from 'src/app/shared.service';
import { filter } from 'rxjs/operators';
import { AppComponent } from '@app/app.component';



@Component({
  selector: 'admin-comp',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

    constructor(private service:SharedService, private app:AppComponent) { }

      ProdList:any=[];

      ModalTitle:string;
      ActivateAddEditDepComp:boolean = false;
      prod:any;

      ProductIdFilter:string ="";
      ProductNameFilter:string = "";
      ProductListWithoutFilter: any =[];
    
      ngOnInit(): void {
        this.refreshProductList();
      }

    openModal() {
        this.prod={
          ProductId:0,
          Name:"",
          Descrit:"",
          Price:0,
          Size:"",
          Color:"",
          Value:0,
          categoryId:0,
          img:"anonymus.jpg",
          img2:null,
          isFavorite:false
        }
        console.log(this.prod);
        this.ModalTitle="Додати товар";
        this.ActivateAddEditDepComp=true;
      }

    editClick(item){
      console.log(item);
      this.prod=item;
      this.ModalTitle="Редагувати інформацію";
      this.ActivateAddEditDepComp=true;
    }

    deleteClick(item){
      if(confirm('Ви впевнені??')){
        this.service.deleteProduct(item.ProductId).subscribe(data=>{
          alert(data.toString());
          this.refreshProductList();
        })
      }
    }
    
      closeModal( ) {
        this.ActivateAddEditDepComp=false;
        this.refreshProductList();
      }

      refreshProductList(){
        this.service.getProdlist().subscribe(data=>{
          this.ProdList=data;
          this.ProductListWithoutFilter=data;
        });
      }

      FilterFn(){
        var ProductNameFilter = this.ProductNameFilter;
    
        this.ProdList = this.ProductListWithoutFilter.filter(function (el){
            return el.Name.toString().toLowerCase().includes(
              ProductNameFilter.toString().trim().toLowerCase()
            )
        });
      }

      getByCategory(val:any){
        this.service.getByCategoryForAdmin(val).subscribe(data=>{
          this.ProdList=data;
        })
      }

      sortResult(prop,asc){
        this.ProdList = this.ProductListWithoutFilter.sort(function(a,b){
          if(asc){
              return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
          }else{
            return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
          }
        })
      }

      logout(){
        this.app.logout();
      }
}






