import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from "rxjs/operators";
import { Router } from '@angular/router';

@Injectable()
export class AuthIntercepter implements HttpInterceptor{
    
    constructor(private router: Router) {
        
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>{
        if(localStorage.getItem('token') != null){
            
            const clonedRequest = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
            });

            return next.handle(clonedRequest).pipe(
                tap(
                    succ => {},
                    err => {
                        if(err.status == 401){
                            localStorage.removeItem('token');
                            this.router.navigate(['/user/login']);
                        }
                        else if(err.status == 403){
                            this.router.navigate(['/home']);
                        }
                    }
                )
            );
        }
        else{
            return next.handle(req.clone());
        }
    }
}