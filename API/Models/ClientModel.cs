using System.ComponentModel.DataAnnotations;
using API.DTO;

namespace API.Models
{
#nullable enable

    public class ClientModel
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string ClientSn { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClientDescription { get; set; }
        public virtual ClientStatusModel ClientStatus { get; set; }
        public virtual ICollection<ProjectModel> Project { get; set; }

        public static implicit operator ClientDto(ClientModel client)
        {
            return new ClientDto()
            {
                ClientId = client.ClientId,
                ClientSn = client.ClientSn,
                ClientName = client.ClientName,
                ClientDescription = client.ClientDescription,
                ClientStatusId = client.ClientStatus.Id
            };
        }
    }
}
