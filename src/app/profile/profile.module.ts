import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Routes } from '@angular/router';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { ExpancerecordComponent } from './expancerecord/expancerecord.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepicker, MatDatepickerModule, MatFormFieldModule, MatInputModule, MatNativeDateModule, MatTabsModule } from '@angular/material';


const routes:Routes =[]

@NgModule({
  declarations: [UserprofileComponent, ExpancerecordComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatTabsModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule ,
    MatInputModule
    
  ],
  exports:[UserprofileComponent,ExpancerecordComponent],
  providers:[MatDatepickerModule]
})
export class profileModule { }
