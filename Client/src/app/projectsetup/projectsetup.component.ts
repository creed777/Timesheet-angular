import "../../services/project.service.ts"
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, RequiredValidator } from '@angular/forms';
import { ProjectModel } from '../../models/project-model';
import { ProjectStatusModel } from '../../models/project-status-model';
import { ProjectService } from "../../services/project.service";
import { ClientModel } from '../../models/client-model';
import { ClientService } from "../../services/client.service";
import { formatDate } from "@angular/common";

@Component({
  selector: 'app-projectsetup',
  templateUrl: './projectsetup.component.html',
  styleUrls: ['./projectsetup.component.css'],
  providers: [ProjectService]
})

export class ProjectsetupComponent implements OnInit {


  constructor(private fb: FormBuilder, private projectService: ProjectService, private clientService: ClientService) { }

  projects: ProjectModel[] = [];
  clients: ClientModel[] = [];
  projectStatus: ProjectStatusModel[] = [];

  projectSetupForm = this.fb.group({
    txtName: [''],
    txtSn: [''],
    txtDescription: [''],
    txtEstTotalHrs: [''],
    txtEstLaborCost: [''],
    ddlStatus: [''],
    ddlClient: [''],
    chkCustomTask: [''],
    txtStartDate: [Date],
    txtEndDate: [Date]
  });

  ngOnInit(): void {
    this.projectService.getAllProjects().subscribe((data) => {
      this.projects = data;
      //this.projects.forEach(x => console.log(x.projectName));
    }, (error) => {
      console.log("an error occured in the project service");
    })

    this.clientService.getAllClients().subscribe((data) => {
      this.clients = data;
      //this.clients.forEach(x => console.log(x.clientName));
    }, (error) => {
      console.log("an error occured in the client service:" + error );
    })

    this.projectService.getAllProjectStatus().subscribe((data) => {
      this.projectStatus = data;
      //this.projectStatus.forEach(x => console.log(x.statusName));
    }, (error) => {
      console.log("an error occured in the client service");
    })
  }

  public onSubmit(): void {
    var statusId: number;
    var clientId: number;

    if (!isNaN(Number(this.projectSetupForm.value.ddlStatus)))
    {
      statusId = Number(this.projectSetupForm.value.ddlStatus);
    } else {
      statusId = 0;
    }

    if (!isNaN(Number(this.projectSetupForm.value.ddlClient))) {
      clientId = Number(this.projectSetupForm.value.ddlClient);
    } else {
      clientId = 0;
    }

    if (!isNaN(Number(this.projectSetupForm.value.ddlProjectManager))) {
      clientId = Number(this.projectSetupForm.value.ddlClient);
    } else {
      clientId = 0;
    }

    if (this.projectSetupForm.value.txtStartDate != undefined || this.projectSetupForm.value.txtStartDate != null) {
      let miliSecDate = Date.parse(this.projectSetupForm.value.txtStartDate.toString());
      var startDate = new Date(miliSecDate)
    }
    else {
      startDate = new Date("1/1/1970")
    }

    if (this.projectSetupForm.value.txtEndDate != undefined || this.projectSetupForm.value.txtEndDate != null) {
      let miliSecDate = Date.parse(this.projectSetupForm.value.txtEndDate.toString());
      var endDate = new Date(miliSecDate)
    }
    else {
      endDate = new Date("1/1/1970")
    }

    let projectSubmit: ProjectModel = {
      projectSn: this.projectSetupForm.value.txtSn?.toString() == null ? '' : this.projectSetupForm.value.txtSn.toString(),
      projectDescription: this.projectSetupForm.value.txtDescription?.toString() == null ? '' : this.projectSetupForm.value.txtDescription.toString(),
      projectName: this.projectSetupForm.value.txtName?.toString() == null ? '' : this.projectSetupForm.value.txtName.toString(),
      projectStatusId: statusId,
      clientId: clientId,
      estimatedStartDate: startDate,
      estimatedEndDate: endDate,
      projectManagerId
    }
      
    console.warn(this.projectSetupForm.value);
  }

  public popup(url: string): void {
    console.warn(url)
  }
}
