import { Injectable } from '@angular/core';
import { Advertising } from '../advertising-panel/models/advertising';
import { HttpClient } from '@angular/common/http';
import { AdvertisingCategory } from '../advertising-panel/models/advertisingCategory';
import { PageInfo } from '../advertising-panel/models/pageInfo';

@Injectable({
  providedIn: 'root'
})
export class AdvertisingService {

  list: Advertising[];
  clist: AdvertisingCategory[];

  pageInfo: PageInfo;

  formData: Advertising;
  formCData: AdvertisingCategory;

  readonly BaseURL = 'https://localhost:5001/api';

  constructor(private http: HttpClient) { }

  postAdvertising(formData: Advertising) {
    return this.http.post(this.BaseURL + "/AdvertisingModels", formData);
  }

  //pagination
  toPage(pageNum: number) {
    return this.http.get(this.BaseURL + '/AdvertisingModels/categoryid=0/page=' + pageNum)
      .toPromise()
      .then(res => this.pageInfo = res as PageInfo);
  }

  toFilteredPage(categoryId: number, title: string, pageNum: number) {
    if (title != null && title != '') {
      return this.http.get(this.BaseURL + '/AdvertisingModels/categoryid=' + categoryId + '/title=' + title + '/page=' + pageNum)
        .toPromise()
        .then(res => this.pageInfo = res as PageInfo);
    }
    else {
      return this.http.get(this.BaseURL + '/AdvertisingModels/categoryid=' + categoryId + '/page=' + pageNum)
        .toPromise()
        .then(res => this.pageInfo = res as PageInfo);
    }
  }

  postAdCategory() {
    return this.http.post(this.BaseURL + "/AdvertisingCategories", this.formCData);
  }

  putAdCategory() {
    return this.http.put(this.BaseURL + "/AdvertisingCategories/" + this.formCData.id, this.formCData);
  }

  deleteAdCategory(adCategoryId: number) {
    return this.http.delete(this.BaseURL + "/AdvertisingCategories/" + adCategoryId);
  }

  updateList() {
    this.http.get(this.BaseURL + '/AdvertisingModels')
      .toPromise()
      .then(res => this.list = res as Advertising[]);
  }

  updateCList() {
    this.http.get(this.BaseURL + '/AdvertisingCategories')
      .toPromise()
      .then(res => this.clist = res as AdvertisingCategory[]);
  }

  getAdDetails(id: number) {
    return this.http.get(this.BaseURL + '/AdvertisingModels/' + id);
  }


}
