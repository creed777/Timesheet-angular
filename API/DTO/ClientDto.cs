using API.Models;

namespace API.DTO
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string ClientSn { get; set; }
        public string ClientName { get; set; }
        public string ClientDescription { get; set; }
        public string ClientStatusName { get; set; }


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
                    ClientStatusName = client.ClientStatusName
                }
            };
        }
    }

    public class CreateClientDto
    {
        public string ClientSn { get; set; }
        public string ClientName { get; set; }
        public string ClientDescription { get; set; }
        public string ClientStatusName { get; set; }

        public static implicit operator ClientModel(CreateClientDto client)
        {
            return new ClientModel
            {
                ClientSn = client.ClientSn,
                ClientName = client.ClientName,
                ClientDescription = client.ClientDescription,
                ClientStatus = new ClientStatusModel()
                {
                    ClientStatusName = client.ClientStatusName,
                }
            };
        }
    }
}
