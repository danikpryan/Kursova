import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import {AdminComponent} from 'src/app/admin/admin.component';


@Component({
  selector: 'app-add-edit-prod',
  templateUrl: './add-edit-prod.component.html',
  styleUrls: ['./add-edit-prod.component.css']
})
export class AddEditProdComponent implements OnInit {

  constructor(private service:SharedService, private admin:AdminComponent) { }

  @Input() prod:any;
   ProductId: string;
   Name: string;
   Descrit:string;
   Price:string;
   Size:string;
   Color:string;
   Value:string;
   categoryId:string;
   isFavorite:boolean;
   img:string;//its PhotoFileName
   img2:string;
   PhotoFilePath:string;
   PhotoFilePath2:string;

   tmp:string;

  CategoryList:any=[];
   
  ngOnInit(): void {
       this.loadCategoryList();
  }
  loadCategoryList(){
    this.service.getAllCategories().subscribe((data:any)=>{
      this.CategoryList=data;

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
      this.isFavorite=this.prod.isFavorite;
      this.PhotoFilePath=this.service.PhotoUrl+this.img;
      this.PhotoFilePath2=this.service.PhotoUrl+this.img2;
    })
  }
  

  addProduct(){
    var val = {ProductId:this.ProductId,
                Name:this.Name,
                Descrit:this.Descrit,
                Price:this.Price,
                Size:this.Size,
                Color:this.Color,
                Value:this.Value,
                categoryId:this.categoryId,
                img:this.img,
                img2:this.img2,
                isFavorite:this.isFavorite}
    this.service.addProduct(val).subscribe(res=>{
      alert(res.toString());
    });
    this.admin.closeModal();
  }

  updateProduct(){
    var val = {
                ProductId:this.ProductId,
                Name:this.Name,
                Descrit:this.Descrit,
                Price:this.Price,
                Size:this.Size,
                Color:this.Color,
                Value:this.Value,
                categoryId:this.categoryId,
                img:this.img,
                img2:this.img2,
                isFavorite:this.isFavorite}
    this.service.updateProduct(val).subscribe(res=>{
    alert(res.toString());
    });
    this.admin.closeModal();
  } 
  
  uploadPhoto(event){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile',file,file.name);

    this.service.UploadPhoto(formData).subscribe((data:any)=>{
      this.img=data.toString();
      this.PhotoFilePath=this.service.PhotoUrl+this.img;
    })
  }

  uploadPhoto2(event){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile',file,file.name);

    this.service.UploadPhoto(formData).subscribe((data:any)=>{
      this.img2=data.toString();
      this.PhotoFilePath2=this.service.PhotoUrl+this.img2;
    })
  }

}
