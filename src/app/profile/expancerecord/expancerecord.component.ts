import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-expancerecord',
  templateUrl: './expancerecord.component.html',
  styleUrls: ['./expancerecord.component.css']
})
export class ExpancerecordComponent implements OnInit {

  expanceRecordform:any
  constructor(public formbuilder: FormBuilder) { }

  ngOnInit() {

    this.expanceRecordform = this.formbuilder.group({

      expancedate:[''],
      expanceItem: ['', Validators.required],
      expanceAmount: ['']
      

    })
  }

}
