import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpanceComponent } from './expance/expance.component';
import { Routes } from '@angular/router';


const routes:Routes =[]

@NgModule({
  declarations: [ExpanceComponent],
  imports: [
    CommonModule
  ]
})
export class MexpanceModule { }
