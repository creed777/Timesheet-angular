//import { HttpClientModule } from '@angular/common/http';
//import { NgModule } from '@angular/core';
//import { BrowserModule } from '@angular/platform-browser';
//import { RouterModule, RouterLink, RouterLinkActive } from '@angular/router';
//import { AppComponent } from './app.component';
//import { HomeComponent } from './home/home.component';
//import { NavMenuComponent } from './nav-menu/nav-menu.component';
//import { ProjectsetupComponent } from './projectsetup/projectsetup.component'
//import { FormsModule, ReactiveFormsModule } from "@angular/forms";

//@NgModule({
//  declarations: [
//    AppComponent,
//    HomeComponent,
//    NavMenuComponent,
//    ProjectsetupComponent,
//    RouterModule,
//    RouterLink,
//    RouterLinkActive,
//    FormsModule,
//    ReactiveFormsModule
//  ],
//  imports: [
//    BrowserModule, HttpClientModule
//  ],
//  providers: [],
//  bootstrap: [AppComponent]
//})
//export class AppModule { }


import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProjectsetupComponent } from './projectsetup/projectsetup.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProjectsetupComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'projectsetup', component: ProjectsetupComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
