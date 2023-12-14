import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import {SharedService} from 'src/app/shared.service';
import { filter } from 'rxjs/operators';



@Component({
  selector: 'cont-component',
  templateUrl: './cont.component.html'
})
export class ContComponent implements OnInit {

    constructor() { }

    ngOnInit(){}

    
}