import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IHistoryOrder } from 'src/app/model/order-history';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html'
})

export class OrderHistoryComponent implements OnInit {
  history: Array<IHistoryOrder> = [];
  formGroup: FormGroup;
  constructor(private router: Router, private http: HttpClient,
    private fb: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit() {

    this.formGroup = this.fb.group({
      dateFrom: [''],
      dateTo: [''],
      priceFrom: [''],
      priceTo: [''],
    });

    this.reload()
  }

  reload() {
    this.http.get<any>('/api/order').subscribe(result => {
      this.history = result;

      this.filterData();
    }, error => console.error(error));
  }

  filter() {
    if (this.history.length == 0)
      this.reload()

    this.filterData();
  }

  filterData() {

    var dateFrom = this.formGroup.get('dateFrom').value;
    var dateTo = this.formGroup.get('dateTo').value;
    var priceFrom = parseFloat(this.formGroup.get('priceFrom').value != "" ?
      this.formGroup.get('priceFrom').value : 0);
    var priceTo = parseFloat(this.formGroup.get('priceTo').value != "" ?
      this.formGroup.get('priceTo').value : 0);

    if (dateFrom != "" && dateTo != "") {
      if (dateFrom > dateTo)
        alert("Date from must be greater than date to");
      else
        this.history = this.history.filter(x => new Date(x.dateOrder).toLocaleDateString() <= new Date(dateFrom).toLocaleDateString() && new Date(x.dateOrder).toLocaleDateString() >= new Date(dateTo).toLocaleDateString());
    }
    if (dateTo != "") {
      if (dateFrom == "")
        alert("You must select date from");
    }
    if (dateFrom != "" && dateTo == "") {
      this.history = this.history.filter(x => x.dateOrder <= dateFrom);
    }

    if (priceFrom != 0 && priceTo != 0) {
      if (priceFrom > priceTo)
        alert("Price from must be greater than price to");
      else
        this.history = this.history.filter(x => x.price <= priceTo && x.price >= priceFrom);
    }

    if (priceTo != 0) {
      if (priceFrom == 0)
        alert("You must select price from");
    }
    if (priceFrom != 0 && priceTo == 0) {
      this.history = this.history.filter(x => x.price >= priceFrom);
    }
  }
}
