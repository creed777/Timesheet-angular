import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { ProjectModel } from '../models/project-model';
import { ProjectStatusModel } from '../models/project-status-model';
import { environment } from '../environments/environment'

@Injectable({
  providedIn: 'root'
})

export class ProjectService {

  constructor(
    private http: HttpClient) { }

  public projects: ProjectModel[] = [];
  public projectStatus: ProjectStatusModel[] = [];

  getAllProjects(): Observable<ProjectModel[]> {
    let projectApi = 'Project/GetAllProjects';
    return this.http
      .get<ProjectModel[]>(environment.apiBaseUrl + projectApi)
      .pipe(map((res: ProjectModel[]) => {
        this.projects = [...res];
        return res;
      }));
  }

  getAllProjectStatus(): Observable<ProjectStatusModel[]> {
    let projectStatusApi = 'Project/GetAllProjectStatus';
    return this.http
      .get<ProjectStatusModel[]>(environment.apiBaseUrl + projectStatusApi)
      .pipe(map((res: ProjectStatusModel[]) => {
        this.projectStatus = [...res];
        return res;
      }));
  }

  processError(err: any) {
    let message = '';
    if (err.error instanceof ErrorEvent) {
      message = err.error.message;
    } else {
      message = `Error Code: ${err.status}\nMessage: ${err.message}`;
    }
    console.log(message);
    return throwError(() => {
      message;
    });

  }

}
