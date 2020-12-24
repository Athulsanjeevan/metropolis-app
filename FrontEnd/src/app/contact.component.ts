import { ApiService } from './api.service';
import { Component } from '@angular/core';


@Component({
    selector:'contact',
    templateUrl:'./contact.component.html'
})

export class ContactComponent{

    contact: any={}
    contacts: any
    
    
    constructor(private api: ApiService){
        this.api.getContact().subscribe(res => { 
            this.contacts = res
        })
    }
}