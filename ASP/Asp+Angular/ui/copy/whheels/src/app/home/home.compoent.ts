import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { ModalService } from '../_modal';
import {SharedService} from '../shared.service';


@Component({
    selector: 'ngbd-carousel-basic',
    styleUrls: ['./home.component.css'],
    templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit{
    
    prod:any;
    FavoriteProducts: any = [];
    PhotoFilePath = this.service.PhotoUrl;
    ActivateProdPage:boolean = false;
    ModalTitle:string;

    constructor(private modalService:ModalService, private service:SharedService,) {
        this.service = service;
    }

    ngOnInit(): void {
        this.getIsFavorite();
    };

    getIsFavorite(){
        this.service.getIsFavorite().subscribe(data=>{
            this.FavoriteProducts = data;
            console.log(data);
        })
    }

    openModal(item){
        this.prod=item;
        this.ModalTitle="Детальніше";
        this.ActivateProdPage=true;
    }
    closeModal(name) {
        this.ActivateProdPage=false;
        this.ModalTitle = name;
        //this.refreshProductList();
    }


}
