import { Component } from '@angular/core';
import { ApiService } from './api.service';


@Component({
  selector: 'nav',
  templateUrl:'./adminlist.component.html'  
  
})
export class AdminListComponent {
  activity: any={}
    activities: any
  constructor(private api: ApiService){
    this.api.getActivity().subscribe(res => { 
        this.activities = res})
    }
  
 
}
