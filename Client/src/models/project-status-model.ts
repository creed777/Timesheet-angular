export class ProjectStatusModel {

  public id: number
  public statusName: string

  constructor(
    id: number,
    statusName: string
  ) {

    this.id = id;
    this.statusName = statusName;
  }
}
