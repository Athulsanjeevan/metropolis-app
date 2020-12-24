import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HttpClientModule } from '@angular/common/http'
import {MatToolbarModule} from '@angular/material/toolbar'; 
import {AdminListComponent} from './adminlist.component'; 
import {MatButtonModule} from '@angular/material/button'; 
import {LoginComponent} from './login.componenet'; 
import {MatCardModule} from '@angular/material/card'; 
import {MatInputModule} from '@angular/material/input'; 

import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { MatListModule } from '@angular/material/list';

import { AuthGuard } from './auth-guard'
import { ApiService } from './api.service'
import {AddActivityComponent} from './addactivity.component';
import { ListActivitiesComponent } from './listactivities.component';
import {JwtModule} from '@auth0/angular-jwt'
import { HomeComponent } from './home.component';
import { ContactComponent } from './contact.component';
import { AdminComponent } from './admin.component';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}



@NgModule({
  declarations: [
    AppComponent,AdminListComponent,LoginComponent,AddActivityComponent,ListActivitiesComponent,HomeComponent,ContactComponent,AdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    MatToolbarModule,MatButtonModule,MatCardModule,MatFormFieldModule,
    FormsModule, ReactiveFormsModule,MatInputModule,MatListModule,
    HttpClientModule,
    JwtModule.forRoot({
    config: {
      tokenGetter: tokenGetter,
      allowedDomains: ["localhost:44335"],
      disallowedRoutes: []
    }
  })
],
  providers: [AuthGuard,ApiService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
