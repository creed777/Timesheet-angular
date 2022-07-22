using API.Models;

namespace API.DTO
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string ClientSn { get; set; }
        public string ClientName { get; set; }
        public string ClientDescription { get; set; }
        public int ClientStatusId { get; set; }


        public static implicit operator ClientModel(ClientDto client)
        {
            return new ClientModel
            {
                ClientId = client.ClientId,
                ClientSn = client.ClientSn,
                ClientName = client.ClientName,
                ClientDescription = client.ClientDescription,
                ClientStatus = new ClientStatusModel()
                {
                    Id = client.ClientStatusId,
                }
            };
        }
    }

    public class CreateClientDto
    {
        public string ClientSn { get; set; }
        public string ClientName { get; set; }
        public string ClientDescription { get; set; }
        public int ClientStatusId { get; set; }

        public static implicit operator ClientModel(CreateClientDto client)
        {
            return new ClientModel
            {
                ClientSn = client.ClientSn,
                ClientName = client.ClientName,
                ClientDescription = client.ClientDescription,
                ClientStatus = new ClientStatusModel()
                {
                    Id = client.ClientStatusId,
                }
            };
        }
    }
}
