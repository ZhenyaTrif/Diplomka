import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { LotService } from 'src/app/shared/lot.service';
import { UserModelInfo } from 'src/app/advertising-panel/models/userModelInfo';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: []
})
export class UserProfileComponent implements OnInit {

  userDetails: UserModelInfo;


  constructor(private router: Router, private service: UserService, private lotservice: LotService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res as UserModelInfo;
        this.lotservice.getMessCapasity(this.userDetails.userId);
      },
      err => {
        console.log(err);
      }
    );

    this.resetForm();

  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
    this.service.passModel = {
      newPassword: ""
    }
  }

  changePassword(form: NgForm){
    this.service.changePassword(form.value).subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success("Пароль изменён.", "Одобрено.");
      },
      err => {
        console.log(err);
      }
    );
  }
}
