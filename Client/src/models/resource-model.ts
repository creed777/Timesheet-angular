export class ResourceModel {

  public resourceId: number;
  public firstName: string;
  public lastName: string;
  public resourceTypeName: string;
  public resourceStatusName: string;

  constructor(ResourceId: number, FirstName: string, LastName: string, ResourceTypeName: string, ResourceStatusName: string ) {
    this.resourceId = ResourceId;
    this.firstName = FirstName;
    this.lastName = LastName;
    this.resourceTypeName = ResourceTypeName;
    this.resourceStatusName = ResourceStatusName;
  }

}
