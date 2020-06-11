import { Component, OnInit } from '@angular/core';
import { LotService } from 'src/app/shared/lot.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auction-lot-list',
  templateUrl: './auction-lot-list.component.html',
  styleUrls: ['./auction-lot-list.component.css']
})
export class AuctionLotListComponent implements OnInit {

  constructor(private lotservice: LotService, private router: Router) { }

  ngOnInit() {
    this.lotservice.updateList();
  }

}
