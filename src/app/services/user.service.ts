import { Injectable } from "@angular/core";
import { Constants } from "../Constants/Constants";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from "../models/User";
import { Observable } from "rxjs";
import { LoginUser } from "../models/LoginUser";
import{ExpanceDetails} from "../models/ExpanceDetails";


@Injectable({
    providedIn:'root'
})
   

export class UserService
{
    url= Constants.apiUrl+"User";
    expanceUrl= Constants.apiUrl+"Expance";

    constructor(public http :HttpClient)
    {

    }

    createUser(user:User): Observable<User>
    {
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
        return this.http.post<User>(this.url + '/InsertUser',user, httpOptions); 
    }

    loginUser(loginuser: LoginUser)    {
        
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
        console.log(loginuser.loginId);
        return this.http.post<any>(this.url+'/login',loginuser,httpOptions);
    }

    expanceData(expanceData : ExpanceDetails){
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
        //console.log(loginuser.loginId);
        return this.http.post<any>(this.expanceUrl+'/InsertExpance',expanceData,httpOptions);
    }

    


}