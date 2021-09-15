import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccounthomepageComponent } from './accounthomepage/accounthomepage.component';



const routes: Routes = [

  {
    path:'',
    redirectTo:'account',
    pathMatch:'full'
  },
  {
    path:'account',
    component:AccounthomepageComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
