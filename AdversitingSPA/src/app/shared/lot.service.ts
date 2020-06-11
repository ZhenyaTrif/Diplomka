import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Lot } from '../advertising-panel/models/lot';
import { Advertising } from '../advertising-panel/models/advertising';
import { AdvertisingService } from './advertising.service';
import { element } from 'protractor';
import { Message } from '../advertising-panel/models/message';
import { UserModelInfo } from '../advertising-panel/models/userModelInfo';

@Injectable({
  providedIn: 'root'
})
export class LotService {

  savedlots: Lot[];
  reklama: Lot[];
  helplist: Advertising[];
  addedlot: Lot;

  reallist: Lot[];

  mymess: number;
  messLots: Lot[];
  messUsers: UserModelInfo[];

  ads: Advertising[];

  messages: Message;


  constructor(private http: HttpClient, private service: AdvertisingService) {}

  readonly BaseURL = 'https://localhost:5001/api';

  postLot(formData: Lot) {
    return this.http.post(this.BaseURL + "/AuctionLot", formData);
  }

  updateList() {
    this.http.get(this.BaseURL + '/AuctionLot')
      .toPromise()
      .then(res => this.reallist = res as Lot[]);
  }

  getLotDetails(id: number) {
    return this.http.get(this.BaseURL + '/AuctionLot/' + id);
  }

  closeLot(data: Lot){
    return this.http.put(this.BaseURL + "/AuctionLot/" + data.id, data);
  }

  getHelpAd(categoryId: number){
    return this.http.get(this.BaseURL + '/AdvertisingModels/categoryid=' + categoryId)
        .toPromise()
        .then(res => this.ads = res as Advertising[]);
  }

  getMessCapasity(id: string){

    this.http.get(this.BaseURL + '/AuctionLot/mess=' + id)
      .toPromise()
      .then(res => {
        this.messLots = res as Lot[];
        this.mymess = this.messLots.length;
      });
  }

  getCreatorInfo(){
    this.http.get(this.BaseURL + '/UserProfile/GetCreatorInfo')
      .toPromise()
      .then(res => {
        this.messUsers = res as UserModelInfo[];
      });
  }

}
