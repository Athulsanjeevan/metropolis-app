import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'admin',
  templateUrl: './admin.component.html',
  styleUrls: []
})
export class AdminComponent {
  customers: any;
 
  constructor(private http: HttpClient) { }
 
  
}