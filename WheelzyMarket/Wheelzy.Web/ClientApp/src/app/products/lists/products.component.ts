import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IProduct } from 'src/app/model/product';
import { Router } from '@angular/router';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ISubCategories } from '../../model/subCategories';
import { ICategories } from '../../model/categories';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})

export class ProductsComponent {
  formGroup: FormGroup;
  products: Array<IProduct>=[];
  catergories: ICategories[];
  subCatergories: ISubCategories[];

  constructor(private router: Router,
    private http: HttpClient,
    private fb: FormBuilder) {

    this.formGroup = this.fb.group({      
      description: [null],
      categoryId: [0],
      subCategoryId: [0],
    });

    this.http.get<any>('/api/categories').subscribe(result => {
      this.catergories = result;
    }, error => console.error(error));

    this.http.get<any>('/api/subcategories').subscribe(result => {
      this.subCatergories = result;
    }, error => console.error(error));

    this.reload(); 
  }

  reload() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    this.http.get<any>('/api/product').subscribe(result => {
      this.products = result;

      if (parseInt(this.formGroup.get('categoryId').value, 10) != 0)
        this.products = this.products.filter(x => x.categoryId === parseInt(this.formGroup.get('categoryId').value, 10));
      if (parseInt(this.formGroup.get('subCategoryId').value, 10) != 0)
        this.products = this.products.filter(x => x.subCategoryId === parseInt(this.formGroup.get('subCategoryId').value, 10));
      if (this.formGroup.get('description').value != '' && this.formGroup.get('description').value != null)
        this.products = this.products.filter(x => x.description.toLowerCase().includes(this.formGroup.get('description').value.toLowerCase()));

      
    }, error => console.error(error));

  }

  filter() {
    if (this.products.length == 0)
      this.reload()
    if (parseInt(this.formGroup.get('categoryId').value, 10) != 0)
      this.products = this.products.filter(x => x.categoryId === parseInt(this.formGroup.get('categoryId').value, 10));
    if (parseInt(this.formGroup.get('subCategoryId').value, 10) != 0)
      this.products= this.products.filter(x => x.subCategoryId === parseInt(this.formGroup.get('subCategoryId').value, 10));
    if (this.formGroup.get('description').value != '' && this.formGroup.get('description').value != null)
      this.products = this.products.filter(x => x.description.toLowerCase().includes(this.formGroup.get('description').value.toLowerCase()));
  }

  newProduct() {
    this.router.navigate(["new"]);
  }

  //Only chage status in DB 
  delete(val) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    this.http.put<any>('/api/product/Delete/'+ val, { headers: headers }).subscribe(result => {
      if (result) {
        alert("Updated successfully");
        this.filter()
      }

    }, error => console.error(error));
  }
}
