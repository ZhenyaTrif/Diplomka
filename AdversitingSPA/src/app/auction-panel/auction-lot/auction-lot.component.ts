import { Component, OnInit } from '@angular/core';
import { Advertising } from 'src/app/advertising-panel/models/advertising';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { LotService } from 'src/app/shared/lot.service';
import { AdvertisingService } from 'src/app/shared/advertising.service';
import { Lot } from 'src/app/advertising-panel/models/lot';
import { LotFull } from 'src/app/advertising-panel/models/lotFull';

@Component({
  selector: 'app-auction-lot',
  templateUrl: './auction-lot.component.html',
  styleUrls: ['./auction-lot.component.css']
})
export class AuctionLotComponent implements OnInit {

  public data: Lot;

  constructor(private service: AdvertisingService, private lotservice: LotService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.updateCList();
    this.lotservice.getHelpAd(1);
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
    this.lotservice.addedlot = {
      id: 0,
      lotName: '',
      text: '',
      imagePath: '',
      startPrice: '',
      lotCategoryId: 1,
      createrId: '',
      checked: true,
      opened: true,
      winnerId: ''
    }
  }

  findHelp(id: number){
    this.lotservice.getHelpAd(id);
  }

  onSubmit(form: NgForm){
    this.lotservice.postLot(form.value).subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success("Лот успешно размещен.", "Одобрено.");
      },
      err => {
        console.log(err);
      }
    );
    window.location.href = "auction";
  }

}
