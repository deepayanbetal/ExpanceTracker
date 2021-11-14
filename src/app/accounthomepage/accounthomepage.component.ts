import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, Routes } from '@angular/router';
import { AppRoutingModule } from '../app-routing.module';
import { LoginUser } from '../models/LoginUser';
import { User } from '../models/User';
import { UserService } from '../services/user.service';
import * as $ from 'jquery';




@Component({
  selector: 'app-accounthomepage',
  templateUrl: './accounthomepage.component.html',
  styleUrls: ['./accounthomepage.component.css']
})


export class AccounthomepageComponent implements OnInit {

  @Input() id : string;
  private element: any;

  loginForm : any
  signUpForm: any
  message : string;
  invalidLogin: boolean;
  modalpopup : boolean;

 
  constructor(public formBuilder: FormBuilder,public userService :UserService, private router : Router,
    private el: ElementRef){
      this.element = el.nativeElement;
    }
   ngOnInit() {
    
    this.loginForm  =  this.formBuilder.group({
      loginId: ['', Validators.required],
      password: ['', Validators.required]
    
    
  });



  this.signUpForm  =  this.formBuilder.group({
    firstname: ['', Validators.required],
    lastname: ['', Validators.required],
    useremail: ['', Validators.required],
    userpassword: ['',Validators.required]
});
  
 }

 onSignUpSubmit()
 {
   console.log(this.userService.url);
   const userVal = this.signUpForm.value;
   userVal.fullname = userVal.firstname+userVal.lastname;
   userVal.userId="testID"+userVal.firstname;
   console.log(userVal);
   this.createUser(userVal);
   this.signUpForm.reset();
 }

 onClose()
 {
  this.loginForm.reset();
  this.invalidLogin = false;
 }
 onLoginSubmit()
 {
  const userVal = this.loginForm.value;
  this.loginUser(userVal);
  
  
 }

 createUser(user :User)
 {
    this.userService.createUser(user).subscribe(
      ()=>{
          this.message="saved";
          console.log(this.message);
          console.log(this.userService.url);
      }
    )
 }

 loginUser(loginUser : LoginUser){

  this.userService.loginUser(loginUser).subscribe
  (response=>{
    const token = (<any>response).Token;
    localStorage.setItem("jwt", token);
    console.log("in loginuser"+loginUser.loginId+" password"+loginUser.password);
      this.invalidLogin = false;
      this.modalpopup = true;
      
      
      
      this.router.navigate(["/profile"]);
    },
      err => {
        this.invalidLogin = true;
      //this.router.navigate(["/"]);
  })
 }

 

}

