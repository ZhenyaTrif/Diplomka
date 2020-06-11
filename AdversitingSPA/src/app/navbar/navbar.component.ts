import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styles: []
})
export class NavbarComponent implements OnInit {

  visibility: boolean = false;
  admin: boolean = true;

  constructor(private router: Router) { }

  ngOnInit() {
    if(localStorage.getItem('token') != null){
      this.visibility = false;
    }
    else{
      this.visibility = true;
    }
  }

  onLogout(){
    localStorage.removeItem('token');
    window.location.href = "user/login";
  }

 // createAd(){
  //  this.router.navigate(['/ad-create']);
  //}
}
