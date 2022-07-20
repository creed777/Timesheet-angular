using API.Models;

namespace API.DTO
{
    public class ClientStatusDto
    {
            public int Id { get; set; }
            public string ClientStatusName { get; set; }

        public static implicit operator ClientStatusModel(ClientStatusDto clientStatusDto)
        {
            return new ClientStatusModel()
            {
                Id = clientStatusDto.Id,
                ClientStatusName = clientStatusDto.ClientStatusName,
            };
        }
    }
}
