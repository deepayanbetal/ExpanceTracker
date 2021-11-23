import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ExpanceDetails } from 'src/app/models/ExpanceDetails';
import { UserService } from 'src/app/services/user.service';



@Component({
  selector: 'app-expancerecord',
  templateUrl: './expancerecord.component.html',
  styleUrls: ['./expancerecord.component.css']
})
export class ExpancerecordComponent implements OnInit {

  expanceRecordform:any;
  message : string;
  constructor(public formbuilder: FormBuilder,public userService :UserService) { }

  ngOnInit() {

    this.expanceRecordform = this.formbuilder.group({

      expancedate:[''],
      expanceItem: ['', Validators.required],
      Price: [''],
      priceBreakUp:[''],
      paymentMethod:[''],
      cashBack:['']
      

    })
  }
  onExpanceRecordSubmit(){
    console.log(this.userService.url);
    const expanceVal = this.expanceRecordform.value;
    console.log(expanceVal);
    this.expanceDataSave(expanceVal);
  }

  expanceDataSave(expanceDetails:ExpanceDetails){

    this.userService.expanceData(expanceDetails).subscribe(
      ()=>{
          this.message="saved";
          console.log(this.message);
          console.log(this.userService.url);
      }
    )

  }
}
