import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: []
})
export class UserProfileComponent implements OnInit {

  userDetails;


  constructor(private router: Router, private service: UserService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
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
