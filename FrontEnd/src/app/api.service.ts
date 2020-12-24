import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';

 
@Injectable()

export class ApiService{

    constructor(private http: HttpClient){

    }
    getActivity(){
        return this.http.get('https://localhost:44335/api/Activity');
     }
     getActivities(){
        return this.http.get('https://localhost:44335/api/Admin');
     }

     getContact(){
        return this.http.get('https://localhost:44335/api/Contact');
     }
    postActivity(form:any){
        this.http.post('https://localhost:44335/api/Activity',form).subscribe(res => {
            console.log(res);
        })
    }   
    }