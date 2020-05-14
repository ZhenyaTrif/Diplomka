import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate, Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private router: Router, private service: UserService) {
    
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if(localStorage.getItem('token') != null){
      
      let roles = next.data['permittedRoles'] as Array<string>;

      if(roles){
        if(this.service.roleMatch(roles)){
          console.log('success');
          return true;
        }
        else{
          console.log('fail');
          this.router.navigate(['/user/login']);
          return false;
        }
      }

      return true;
    }
    else{
      this.router.navigate(['/user/login']);
      return false;
    }
  }

}
