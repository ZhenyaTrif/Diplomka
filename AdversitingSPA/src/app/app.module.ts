import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgbModule, NgbPaginationModule} from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AuthIntercepter } from './auth/auth.interceptor';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { AdvertisingComponent } from './advertising-panel/advertising/advertising.component';
import { AdvertisingCategoryComponent } from './advertising-panel/advertising-category/advertising-category.component';
import { UserProfileComponent } from './user/user-profile/user-profile.component';
import { AdvertisingListComponent } from './advertising-panel/advertising-list/advertising-list.component';
import { AdvertisingService } from './shared/advertising.service';
import { AdvertisingDetailsComponent } from './advertising-panel/advertising-details/advertising-details.component';
import { AdvertisingCategoryListComponent } from './advertising-panel/advertising-category-list/advertising-category-list.component';
import { AdvertisingCategoryMenuComponent } from './advertising-panel/advertising-category-menu/advertising-category-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    NavbarComponent,
    AdminPanelComponent,
    AdvertisingComponent,
    AdvertisingCategoryComponent,
    UserProfileComponent,
    AdvertisingListComponent,
    AdvertisingDetailsComponent,
    AdvertisingCategoryListComponent,
    AdvertisingCategoryMenuComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgbModule,
    NgbPaginationModule
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthIntercepter,
    multi: true
  }, AdvertisingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
