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
import { DatasetupComponent } from './datasetup/datasetup.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ResourceDialogComponent } from './datasetup/editresource/editresource.component';  
import { MatDialogModule } from "@angular/material";
import { DialogComponent } from './shared/dialog/dialog.component';

//@angular/cdk/a11y
//  - @angular/cdk/coercion
//    - @angular/cdk/bidi
//      - @angular/cdk/keycodes
//        - @angular/cdk/overlay
//          - @angular/cdk/portal
//  - @angular/cdk/scrolling

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProjectsetupComponent,
    DatasetupComponent,
    ResourceDialogComponent,
    DialogComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgbModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'projectsetup', component: ProjectsetupComponent },
      { path: 'datasetup', component: DatasetupComponent }
    ]),
    MatDialogModule
  ],

  exports: [MatDialogModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
