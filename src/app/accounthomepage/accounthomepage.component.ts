import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginUser } from '../models/LoginUser';
import { User } from '../models/User';
import { UserService } from '../services/user.service';





@Component({
  selector: 'app-accounthomepage',
  templateUrl: './accounthomepage.component.html',
  styleUrls: ['./accounthomepage.component.css']
})


export class AccounthomepageComponent implements OnInit {

  loginForm : any
  signUpForm: any
  message : string;
  invalidLogin: boolean;

 
  constructor(public formBuilder: FormBuilder,public userService :UserService){}
   ngOnInit() {
    
    this.loginForm  =  this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    
    
  });



  this.signUpForm  =  this.formBuilder.group({
    firstname: ['', Validators.required],
    lastname: ['', Validators.required],
    email: ['', Validators.required],
    password: ['',Validators.required]
});
  
 }

 onSignUpSubmit()
 {
   console.log(this.userService.url);
   const userVal = this.signUpForm.value;
   userVal.userId="testID"+userVal.firstname;
   this.createUser(userVal);
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
      this.invalidLogin = false;},
      err => {
        this.invalidLogin = true;
      //this.router.navigate(["/"]);
  })
 }

}

