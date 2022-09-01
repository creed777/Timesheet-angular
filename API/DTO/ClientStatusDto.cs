using API.Models;

namespace API.DTO
{
    public class ClientStatusDto
    {
            public string ClientStatusName { get; set; }

        public static implicit operator ClientStatusModel(ClientStatusDto clientStatusDto)
        {
            return new ClientStatusModel()
            {
                ClientStatusName = clientStatusDto.ClientStatusName,
            };
        }
    }
}
