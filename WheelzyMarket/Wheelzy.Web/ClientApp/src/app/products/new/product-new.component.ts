import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ICategories } from 'src/app/model/categories';
import { ISubCategories } from 'src/app/model/subCategories';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-products-new',
  templateUrl: './product-new.component.html'
})

export class ProductsNewComponent implements OnInit {
  formGroup: FormGroup;
  catergories: ICategories[];
  subCatergories: ISubCategories[];
  subCatergoriesFilter: ISubCategories[];
  productId: number;

  constructor(private router: Router, private http: HttpClient,
    private fb: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit() {

    this.http.get<any>('/api/categories').subscribe(result => {
      this.catergories = result;
    }, error => console.error(error));

    this.http.get<any>('/api/subcategories').subscribe(result => {
      this.subCatergories = result;
    }, error => console.error(error));

    this.formGroup = this.fb.group({
      id:[null],
      code: ['', Validators.required],
      description: ['', Validators.required],
      categoryId: [0, Validators.required],
      subCategoryId: [0, Validators.required],
      price: ['', Validators.required],
      status: [false]
    });

    if (this.route.snapshot.paramMap.has("id")) {
      const headers = new HttpHeaders({
        'Content-Type': 'application/json'
      });

      this.productId = parseInt(this.route.snapshot.paramMap.get('id'), 10);
      this.http.get<any>('/api/product/GetById/' + this.productId, { headers: headers }).subscribe(result => {
        this.formGroup.patchValue(result);
        this.subCatergoriesFilter = this.subCatergories.filter(x => x.categoryId.toString() == this.formGroup.get('categoryId').value);
      }, error => console.error(error));

    }

  }

  onChange(val) {
    this.subCatergoriesFilter = this.subCatergories.filter(x => x.categoryId.toString() == val);
  }

  onSubmit() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    const body = JSON.stringify(this.formGroup.value);
    
    if (this.productId) {
      this.http.put<any>('/api/product', body, { headers: headers }).subscribe(result => {
        if (result) {
          alert("Updated successfully");
          this.router.navigate(['product-list']);
        }

      }, error => console.error(error));
    }
    else {
      this.http.post<any>('/api/product', body, { headers: headers }).subscribe(result => {
        if (result) {
          alert("Saved successfully");
          this.formGroup.reset();
        }

      }, error => console.error(error));
    }
  }

  cancel() {
    this.router.navigate(["product-list"]);
  }
}
