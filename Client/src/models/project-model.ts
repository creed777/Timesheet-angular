export class ProjectModel {

  public projectSn: string;
  public projectName: string;
  public projectDescription: string;
  public clientId: number;
  public divisionId: number;
  public estimatedStartDate: Date;
  public estimatedEndDate: Date;
  public actualStartDate?: Date;
  public actualEndDate?: Date;
  public projectManagerId?: number;
  public estimatedTotalHours?: number;
  public actualTotalHours?: number;
  public estimatedLaborCost?: number;
  public actualLaborCost?: number;
  public estimatedMaterialCost?: number;
  public actualMaterialCost?: number;
  public projectStatusId: number;

  constructor(projectSn: string,
    projectName: string,
    projectDescription: string,
    clientId: number,
    divisionId: number,
    estimatedStartDate: Date,
    estimatedEndDate: Date,
    actualStartDate: Date,
    actualEndDate: Date,
    projectManagerId: number,
    estimatedTotalHours: number,
    actualTotalHours: number,
    estimatedLaborCost: number,
    actualLaborCost: number,
    estimatedMaterialCost: number,
    actualMaterialCost: number,
    projectStatusId: number,) {

    this.projectSn = projectSn;
    this.projectName = projectName;
    this.projectDescription = projectDescription;
    this.clientId = clientId;
    this.divisionId = divisionId;
    this.estimatedStartDate = estimatedStartDate;
    this.estimatedEndDate = estimatedEndDate;
    this.actualStartDate = actualStartDate;
    this.actualEndDate = actualEndDate;
    this.projectManagerId = projectManagerId;
    this.estimatedTotalHours = estimatedTotalHours;
    this.actualTotalHours = actualTotalHours;
    this.estimatedLaborCost = estimatedLaborCost;
    this.actualLaborCost = actualLaborCost;
    this.estimatedMaterialCost = estimatedMaterialCost;
    this.actualMaterialCost = actualMaterialCost;
    this.projectStatusId = projectStatusId;
  }


}
