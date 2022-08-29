import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ResourceModel } from '../models/resource-model';

import { environment } from '../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class ResourceService {

  constructor(private http: HttpClient) { }

  public clients: ResourceModel[] = [];

  getAllClients(): Observable<ResourceModel[]> {
    let clientApi = 'Resource/GetResourceByType';
    return this.http
      .get<ResourceModel[]>(environment.apiBaseUrl + clientApi)
      .pipe(map((res: ResourceModel[]) => {
        this.resources = [...res];
        return res;
      }));
  }

}
