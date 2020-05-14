import { Component, OnInit } from '@angular/core';
import { AdvertisingService } from 'src/app/shared/advertising.service';
import { AdvertisingCategory } from '../models/advertisingCategory';

@Component({
  selector: 'app-advertising-category-list',
  templateUrl: './advertising-category-list.component.html',
  styles: []
})
export class AdvertisingCategoryListComponent implements OnInit {

  constructor(private service: AdvertisingService) { }

  ngOnInit() {
    this.service.updateCList();
  }

  populateForm(category: AdvertisingCategory) {
    this.service.formCData = Object.assign({}, category);
  }

  deleteCat(category: AdvertisingCategory) {
    this.service.deleteAdCategory(category.id).subscribe(data => {
      this.service.updateCList();
    });
  }
}
