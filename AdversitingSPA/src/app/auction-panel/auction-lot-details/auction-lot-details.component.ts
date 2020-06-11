import { Component, OnInit } from '@angular/core';
import { LotService } from 'src/app/shared/lot.service';
import { Router, ActivatedRoute } from '@angular/router';
import { LotFull } from 'src/app/advertising-panel/models/lotFull';
import { Lot } from 'src/app/advertising-panel/models/lot';

@Component({
  selector: 'app-auction-lot-details',
  templateUrl: './auction-lot-details.component.html',
  styleUrls: ['./auction-lot-details.component.css']
})
export class AuctionLotDetailsComponent implements OnInit {

  lotDetails;
  ownPrice: number;
  lotCategory;
  lotId: number;
  private sub: any;

  constructor(private lotservice: LotService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.lotId = +params['id']
    });

    this.getDetails();
  }

  getDetails(){
    this.lotservice.getLotDetails(this.lotId).subscribe(
      res => {
        this.lotDetails = res as LotFull;
        this.ownPrice = Number(this.lotDetails.startPrice);
      },
      err => {
        console.log(err);
      }
    );
  }

  makeBet(){
    this.ownPrice += 100;
  }

  closeLot() {
    let changedlot: Lot;
    changedlot = {
      id: this.lotDetails.id,
      lotName: this.lotDetails.lotName,
      text: this.lotDetails.text,
      imagePath: this.lotDetails.imagePath,
      startPrice: this.ownPrice.toString(),
      lotCategoryId: this.lotDetails.lotCategoryId,
      createrId: this.lotDetails.createrId,
      checked: this.lotDetails.checked,
      opened: false,
      winnerId: "06fb596d-baae-44ea-93f6-d14120c7a8f9"
    }
    this.lotservice.closeLot(changedlot).subscribe(data => {
      this.lotservice.updateList();
    });
    window.location.href = "auction";
  }
}
