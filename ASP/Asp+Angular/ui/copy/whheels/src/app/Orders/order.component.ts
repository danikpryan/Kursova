import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import {SharedService} from 'src/app/shared.service';
import { filter } from 'rxjs/operators';



@Component({
  selector: 'order-comp',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

    OrderList:any=[];
    ModalTitle:string='www';
    prod:any;
    ActivateAddEditDepComp:boolean;

    constructor(private service:SharedService) { }
 
      ngOnInit(): void {
          this.refreshOrderList();
      }

    refreshOrderList(){
        this.service.getOrders().subscribe(data=>{
            this.OrderList=data;
            console.log(data);
        }) 
    }

    detailClick(item){
      console.log(item);
       this.prod=item;
       this.ModalTitle="Детальніше";
       this.ActivateAddEditDepComp=true;
    }

    closeModal( ) {
      this.ActivateAddEditDepComp=false;
    }
}