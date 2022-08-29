export class ClientStatusModel {
  public Id: number;
  public ClientStatusName: string

  constructor(
    id: number,
    clientStatusName: string
  ) {
    this.ClientStatusName = clientStatusName;
    this.Id = id
  }

}
