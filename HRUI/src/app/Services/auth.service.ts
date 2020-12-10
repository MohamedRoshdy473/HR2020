import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { InnerSubscriber } from 'rxjs/internal/InnerSubscriber';
import { IUser } from 'src/app/Data_Types/iuser'
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

   httpOptions = {headers: new HttpHeaders({
    'Content-Type': 'application/json',
    "Authorization": "bearer " + localStorage.getItem('token')
      })};
  user: IUser;
  constructor(private httpclient: HttpClient,private router : Router) {
    
  }

  login(user:IUser) {
    //console.log(user)
    var data = "email=" +user.email + "&password=" + user.password + "&grant_type=password";
    var reqHeader = new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': '*/*'
    });
    
    return this.httpclient.post(`${environment.ApiURL}/Authenticate/login`, user, this.httpOptions)
    ;
  }
  loggedIn()
  {
    return !! localStorage.getItem('token');
  }
  logout()
  {
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }
  IsAdmin()
  {
    return localStorage.getItem('roles') == 'Admin';
  }
  IsUser()
  {
    return localStorage.getItem('roles') == 'User';
  }
  changPassword(NewPassword:string)
  {
    var data={
      userName:localStorage.getItem('userName'),
      password:"M@sTech146",
      Newpassword:NewPassword
    };
    return this.httpclient.post(`${environment.ApiURL}/Authenticate/changPassword`, data, this.httpOptions)
  }
  checkInterceptor()
  {
    return this.httpclient.get(`${environment.ApiURL}/Authenticate/checkInterceptor`,this.httpOptions)
  }
}
