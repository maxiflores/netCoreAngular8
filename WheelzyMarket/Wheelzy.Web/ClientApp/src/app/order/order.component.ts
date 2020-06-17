import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IProduct } from 'src/app/model/product';
import { IOrder } from 'src/app/model/order';

@Component({
  selector: 'app-orders',
  templateUrl: './order.component.html'
})

export class OrdersComponent implements OnInit {
  formGroup: FormGroup;
  products: IProduct[];
  prodctOrder: Array<IOrder> = [];

  constructor(private router: Router, private http: HttpClient,
    private fb: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.http.get<any>('/api/product/GetAllAvailables').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

  addToOrder(id: any) {
    
    var prodAdd = this.products.find(x => x.id == id);
    var existProd = this.prodctOrder.findIndex(x => x.id == id);

    if (existProd == -1) {
      var objAdd = {
        "id": prodAdd.id, "code": prodAdd.code, "description": prodAdd.description,
        "category": prodAdd.category, "subCategory": prodAdd.subCategory, "categoryId": prodAdd.categoryId,
        "subCategoryId": prodAdd.subCategoryId, "price": prodAdd.price, "quantity": 1
      };
      this.prodctOrder.push(objAdd);
    }
    else {

      var exist = this.prodctOrder.find(x => x.id == id);
      this.prodctOrder.splice(existProd);
      var objAdd = {
        "id": exist.id, "code": exist.code, "description": exist.description,
        "category": exist.category, "subCategory": exist.subCategory, "categoryId": prodAdd.categoryId,
        "subCategoryId": prodAdd.subCategoryId,"price": exist.price, "quantity": exist.quantity+1
      };
      this.prodctOrder.push(objAdd);
      
    }
  }

  removeToOrder(id: any) {
    var prodMinus = this.prodctOrder.findIndex(x => x.id == id);

    this.prodctOrder.splice(prodMinus,1);
  }

  completeOrder() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    const body = JSON.stringify(this.prodctOrder);

    this.http.post<any>('/api/order', body, { headers: headers }).subscribe(result => {
      if (result) {
        alert("Saved successfully");
        this.prodctOrder = [];
      }

    }, error => console.error(error));
  }
}
