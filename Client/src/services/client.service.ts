import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ClientModel } from '../models/client-model';
import { ClientStatusModel } from '../models/client-status-model';
import { environment } from '../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(
    private http: HttpClient) { }

  public clients: ClientModel[] = [];
  public clientStatus: ClientStatusModel[] = [];

  getAllClients(): Observable<ClientModel[]> {
    let clientApi = 'Client/GetAllClients';
    return this.http
      .get<ClientModel[]>(environment.apiBaseUrl + clientApi)
      .pipe(map((res: ClientModel[]) => {
        this.clients = [...res];
        return res;
      }));
  }

  getAllClientStatus(): Observable<ClientStatusModel[]> {
    let clientApi = 'Client/GetAllClientStatus';
    return this.http
      .get<ClientStatusModel[]>(environment.apiBaseUrl + clientApi)
      .pipe(map((res: ClientStatusModel[]) => {
        this.clientStatus = [...res];
        return res;
      }));
  }

}
