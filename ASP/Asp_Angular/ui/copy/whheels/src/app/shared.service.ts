import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';  
import { from } from 'rxjs';
import {Guid} from 'guid-typescript';
import { Cart } from "src/app/cart/cart.model";

@Injectable({
  providedIn: 'root'
})

export class SharedService {
// readonly APIUrl = "http://localhost:5000/api";
readonly PhotoUrl = "http://localhost:5000/Photos/";
readonly APIUrl = "http://localhost:5000/api"


  constructor(private http:HttpClient,  private cart: Cart) { }

  getTest():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Product');
  }

  getProdlist():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/Admin');
  } 

  getProduct(val:any){
    return this.http.get(this.APIUrl+'/Admin',val);
  } 

  getByCategory(val:any){
    return this.http.get(this.APIUrl+'/Category/'+val);
  }

  getByCategoryForAdmin(val:any){
    return this.http.get(this.APIUrl+'/Admin/'+val);
  }

  addProduct(val:any){
    return this.http.post(this.APIUrl+'/Admin',val);
  }

  updateProduct(val:any){
    return this.http.put(this.APIUrl+'/Admin',val);
  }

  deleteProduct(val:any){
    return this.http.delete(this.APIUrl+'/Admin/'+val);
  }

  UploadPhoto(val:any){
    return this.http.post(this.APIUrl+'/Admin/SaveFile',val);
  }

  GetAllProducts():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Product/GetAllProducts');
  }

  getAllCategories():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Product/GetAllCategories');
  }

  getProd(val:any){
    return this.http.get(this.APIUrl+'/Product/'+val);
  }

  getM():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/Product/');
  } 

  getAllSize(val:any, color:any){
    return this.http.get<any>(this.APIUrl + '/Product/GetSize/'+val + '/' + color);
  }

  changeSize(size:any, color:any, name:any){
    return this.http.get(this.APIUrl+'/Product/'+size + '/' + color + '/' + name);
  }

  getIsFavorite(){
    return this.http.get(this.APIUrl+'/Product/GetIsFavorite')
  }

  saveOrder(val:any, id:any){
    return this.http.post(this.APIUrl+'/Order/' + id, val);
  }

  saveOrdersProduct(val:any=[], id:any){
    console.log(val);
    return this.http.post(this.APIUrl+'/Order/second/' + id, val);
  }

  getOrders():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/Order');
  }

  getDetail(val:any):Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/Order/'+val);
  }

  getDetailProd(val:any):Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/Test/' + val);
  }

  updt(val:any){
    return this.http.put(this.APIUrl+'/Order', val);
    console.log(val);
  }
}
