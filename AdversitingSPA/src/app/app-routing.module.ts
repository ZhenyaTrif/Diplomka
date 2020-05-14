import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { UserProfileComponent } from './user/user-profile/user-profile.component';
import { AdvertisingComponent } from './advertising-panel/advertising/advertising.component';
import { AdvertisingDetailsComponent } from './advertising-panel/advertising-details/advertising-details.component';
import { AdvertisingListComponent } from './advertising-panel/advertising-list/advertising-list.component';

const routes: Routes = [
  {path:'', redirectTo:'home', pathMatch:'full'},
  {path:'user', component: UserComponent, children:[
    {path:'registration', component: RegistrationComponent},
    {path:'login', component: LoginComponent},
    {path:'profile', component: UserProfileComponent, canActivate: [AuthGuard]}
  ]},
  {path:'home', component: AdvertisingListComponent},
  {path:'ad-create', component: AdvertisingComponent, canActivate: [AuthGuard]},
  {path:'home/ad-details/:id', component: AdvertisingDetailsComponent},
  {path:'admin-panel', component: AdminPanelComponent, canActivate: [AuthGuard], data: {permittedRoles:['Admin']}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
