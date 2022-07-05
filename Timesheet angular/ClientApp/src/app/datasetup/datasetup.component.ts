import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DialogComponent } from '../shared/dialog/dialog.component';

interface Resource {
  name: string;
  type: string;
  rate: number;
}

@Component({
  selector: 'app-datasetup',
  templateUrl: './datasetup.component.html',
  styleUrls: ['./datasetup.component.css']
})
export class DatasetupComponent implements OnInit {
  active = 1
  page = 1;
  pageSize = 4;
  collectionSize: number = 0;
  currentRate = 8;
  resources: Resource[] = [];
  showDialog = false;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<Resource[]>('/assets/ResourceDummyData.json')
      .subscribe((data: Resource[]) => {
        this.collectionSize = data.length;
        this.resources = data;
      });
  }

  public editResource(r: Resource) {
    this.showDialog = !this.showDialog
  }

}
