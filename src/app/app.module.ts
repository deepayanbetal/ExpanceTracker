import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccounthomepageComponent } from './accounthomepage/accounthomepage.component';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { ProfileComponent } from './profile/profile.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule, MatFormFieldModule, MatInputModule, MatTabsModule } from '@angular/material';


import { profileModule } from './profile/profile.module';



export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    AccounthomepageComponent,
    ProfileComponent
  
    
   
    
   
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:64376"],
        blacklistedRoutes: []
      }
    }),
    BrowserAnimationsModule,
    MatTabsModule,
    profileModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatInputModule


    
   
  ],
  
  providers: [],
  bootstrap: [AppComponent],
  
})
export class AppModule { }
