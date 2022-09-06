import "../../services/project.service.ts"
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, RequiredValidator } from '@angular/forms';
import { ProjectModel } from '../../models/project-model';
import { ProjectStatusModel } from '../../models/project-status-model';
import { ProjectService } from "../../services/project.service";
import { ResourceService } from "../../services/resource.service";
import { ClientModel } from '../../models/client-model';
import { ResourceModel } from '../../models/resource-model';
import { ClientService } from "../../services/client.service";
import { SpinnerComponent } from "../../app/spinner/spinner.component";
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { lastValueFrom } from "rxjs";

@Component({
  selector: 'app-projectsetup',
  templateUrl: './projectsetup.component.html',
  styleUrls: ['./projectsetup.component.css'],
  providers: [ProjectService]
})

export class ProjectsetupComponent implements OnInit {

  constructor(private fb: FormBuilder, private projectService: ProjectService, private clientService: ClientService, private resourceService: ResourceService,
    public spinner: MatDialog) { }

  projects: ProjectModel[] = [];
  clients: ClientModel[] = [];
  projectStatus: ProjectStatusModel[] = [];
  projectManager: ResourceModel[] = [];

  projectSetupForm = this.fb.group({
    txtName: [''],
    txtSn: [''],
    txtDescription: [''],
    txtEstTotalHrs: [''],
    txtEstLaborCost: [''],
    ddlProjectMgr: [''], 
    ddlStatus: [''],
    ddlClient: [''],
    chkCustomTask: [''],
    txtStartDate: [Date], 
    txtEndDate: [Date]
  });

  async ngOnInit() {

    this.showSpinner();
    await this.loadData()
    this.hideSpinner();
  }

  private async loadData() {
    let projectData = await lastValueFrom(this.projectService.getAllProjects());
    this.projects = projectData;

    var clientData = await lastValueFrom(this.clientService.getAllClients());
      this.clients = clientData;

    let projectStatusData = await lastValueFrom(this.projectService.getAllProjectStatus());
      this.projectStatus = projectStatusData;


    let resourceData = await lastValueFrom(this.resourceService.getAllProjectMgrs());
      this.projectManager = resourceData;
}

  private showSpinner(): void {

    const spinnerConfig = new MatDialogConfig();
    spinnerConfig.disableClose = true;
    spinnerConfig.autoFocus = true;
    spinnerConfig.width = '400px';
    spinnerConfig.height = '150px';
    spinnerConfig.closeOnNavigation = false;
    spinnerConfig.disableClose = true;
    spinnerConfig.hasBackdrop = true;

    this.spinner.open(SpinnerComponent, spinnerConfig)
  }

  private hideSpinner(): void {
    this.spinner.closeAll()
  }

  public onSubmit(): void {
    var statusId: number;
    var clientId: number;
    var projectMgrId: number;

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

    if (!isNaN(Number(this.projectSetupForm.value.ddlProjectMgr))) {
      projectMgrId = Number(this.projectSetupForm.value.ddlProjectMgr);
    } else {
      projectMgrId = 0;
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
      divisionId: 0,
      estimatedStartDate: startDate,
      estimatedEndDate: endDate,
      actualStartDate: undefined,
      actualEndDate: undefined,
      projectManagerId: projectMgrId,
      estimatedTotalHours: undefined,
      actualTotalHours: undefined,
      estimatedLaborCost: undefined,
      actualLaborCost: undefined,
      estimatedMaterialCost: undefined,
      actualMaterialCost: undefined
    }

    this.projectService.submitProjectForm(projectSubmit);
    console.warn(this.projectSetupForm.value);
  }

  public popup(url: string): void {
    console.warn(url)
  }
}
