import { Component, OnInit } from '@angular/core';
import { AdvertisingService } from 'src/app/shared/advertising.service';
import { Advertising } from '../models/advertising';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-advertising-list',
  templateUrl: './advertising-list.component.html',
  styleUrls: ['./advertising-list.component.css']
})
export class AdvertisingListComponent implements OnInit {

  constructor(private service: AdvertisingService, private router: Router) { }

  ngOnInit() {

    this.service.pageInfo = {
      ads: [],
      pageModel: {
        pageNumber: 1,
        totalPages: 1,
        hasPreviousPage: false,
        hasNextPage: false
      },
      filterModel: {
        categories: [],
        selectedCategory: 0,
        selectedTitle: ''
      }
    }

    this.service.toPage(1);
  }

  toNextPage(){
    if(this.service.pageInfo.pageModel.pageNumber < this.service.pageInfo.pageModel.totalPages){
      this.service.toFilteredPage(this.service.pageInfo.filterModel.selectedCategory, this.service.pageInfo.filterModel.selectedTitle, this.service.pageInfo.pageModel.pageNumber + 1);
    }
  }

  toPreviousPage(){
    if(this.service.pageInfo.pageModel.pageNumber != 1){
      this.service.toFilteredPage(this.service.pageInfo.filterModel.selectedCategory, this.service.pageInfo.filterModel.selectedTitle, this.service.pageInfo.pageModel.pageNumber - 1);
    }
  }

  onSearch(form: NgForm){
    this.service.toFilteredPage(form.value.selectedCategory, form.value.searchTitle, 1);
  }
}
