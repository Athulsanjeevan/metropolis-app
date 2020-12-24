import { ApiService } from './api.service';
import { Component } from '@angular/core';


@Component({
    selector:'addactivity',
    templateUrl:'./addactivity.component.html'
})

export class AddActivityComponent{

    activity: any={}
    
    constructor(private api: ApiService){}
    post(activity: any){

        this.api.postActivity(activity);
    }

}
