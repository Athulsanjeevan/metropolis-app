import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { NgForm } from '@angular/forms';

@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  invalidLogin:any;

  constructor(private router: Router, private http: HttpClient) { }
  public login(form: NgForm){
    const credentials = JSON.stringify({
      'email':form.value.username,
      'password':form.value.password
  });
    this.http.post("https://localhost:44335/api/Admin",credentials,{
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })          
    }).subscribe(response => {      
      const token = (<any>response).token;
      const refreshToken = (<any>response).refreshToken;
      localStorage.setItem("jwt", token);
      localStorage.setItem("refreshToken", refreshToken);
      this.invalidLogin = false;
      this.router.navigate(["nav"]);
    }, err => {
      this.invalidLogin = true;
    });
  }
}