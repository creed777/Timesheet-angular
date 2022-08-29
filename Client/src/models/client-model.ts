export class ClientModel {
  public clientId: number;
  public clientSn: string;
  public clientName: string;
  public clientDescription: string;

  constructor(
    clientId: number,
    clientSn: string,
    clientName: string,
    clientDescription: string
  )
  {
    this.clientId = clientId,
    this.clientSn = clientSn,
    this.clientName = clientName,
    this.clientDescription = clientDescription
  };
}
