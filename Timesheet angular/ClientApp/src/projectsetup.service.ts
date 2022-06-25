import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { getBaseUrl } from './main';

@Injectable({
  providedIn: 'root'
})
export class ProjectsetupService {

  url = "https://localhost:4200";
  apiUrl: string = "";
  constructor(private _http: HttpClient, @Inject('url') baseUrl: string,)
  {
    this.apiUrl = this.url;
  }

}
