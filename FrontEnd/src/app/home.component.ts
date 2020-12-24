import { Component} from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ApiService } from './api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: []
})
export class HomeComponent {

  constructor(private jwtHelper: JwtHelperService, private router: Router,private api: ApiService) {
    this.api.getActivities().subscribe(res => { 
      this.activities = res
  })
  }
  activity: any={}
  activities: any

  public isUserAuthenticated() {
    const token: any = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

   logOut(){
    localStorage.removeItem("jwt");
    localStorage.removeItem("refreshToken");
  }
  
}