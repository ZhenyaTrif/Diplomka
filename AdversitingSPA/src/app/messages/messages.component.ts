import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LotService } from '../shared/lot.service';
import { UserModelInfo } from '../advertising-panel/models/userModelInfo';
import { Lot } from '../advertising-panel/models/lot';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {

  constructor(private router: Router, private lotservice: LotService) { }

  userInfo: UserModelInfo[];

  ngOnInit() {

    this.lotservice.getCreatorInfo();
  }



}
