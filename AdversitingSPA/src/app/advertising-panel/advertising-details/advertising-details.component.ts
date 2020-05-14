import { Component, OnInit } from '@angular/core';
import { AdvertisingService } from 'src/app/shared/advertising.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-advertising-details',
  templateUrl: './advertising-details.component.html',
  styles: []
})
export class AdvertisingDetailsComponent implements OnInit {

  adDetails;
  adCategory;
  adId: number;
  private sub: any;

  constructor(private service: AdvertisingService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.adId = +params['id']
    });

    this.getDetails();
  }

  getDetails(){
    this.service.getAdDetails(this.adId).subscribe(
      res => {
        this.adDetails = res;
      },
      err => {
        console.log(err);
      }
    );
  }

}
