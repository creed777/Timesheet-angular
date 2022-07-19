using API.Models;

namespace API.DTO
{
    public class ClientDto
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientDescription { get; set; }
        public int ClientStatusId { get; set; }


        public static implicit operator ClientModel(ClientDto client)
        {
            return new ClientModel
            {
                ClientSn = client.ClientId,
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
