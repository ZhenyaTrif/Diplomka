import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  constructor(public service:UserService, private toastr: ToastrService, private router: Router) { }

  ngOnInit() {
    if(localStorage.getItem('token') != null){
      this.router.navigate(['/home']);
    }
    else{
      this.service.formModel.reset();
    }
  }

  onSubmit(){
    this.service.register().subscribe(
      (res:any) => {
        if(res.succeeded){
          this.service.formModel.reset();
          this.toastr.success('Новый пользователь зарегистрирован.', 'Регистрация прошла успешно.');
        }
        else{
          res.errors.forEach(element => {
            switch(element.code){
              case 'DuplicateUserName':{
                this.toastr.error('Такое Имя пользователя уже используется.', 'Регистрация отменена.');
                break;
              }
              default:{
                this.toastr.error(element.description, 'Регистрация отменена.');
                break;
              }
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}
