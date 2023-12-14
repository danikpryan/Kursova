import { SharedService } from 'src/app/shared.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'test',
  templateUrl: './teston10.component.html'
})
export class teston10 implements OnInit {

  productList:any = [];

  constructor(private service:SharedService) {
    this.service = service;
   }

  ngOnInit():void{
      this.refreshProdList();
  }

  refreshProdList(){
    console.log("In function");
    this.service.getTest().subscribe(data=>{
        console.log(data);
        this.productList = data;
      })
}
}
