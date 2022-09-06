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
        public string ClientSn { get; set; } = string.Empty;
        [Required]
        public string ClientName { get; set; } = string.Empty;
        [Required]
        public string ClientDescription { get; set; } = string.Empty;
        public virtual ClientStatusModel ClientStatus { get; set; } = new ClientStatusModel();
        public virtual ICollection<ProjectModel> Project { get; set; } = new List<ProjectModel>();

        public static implicit operator ClientDto(ClientModel client)
        {
            return new ClientDto()
            {
                ClientId = client.ClientId,
                ClientSn = client.ClientSn,
                ClientName = client.ClientName,
                ClientDescription = client.ClientDescription,
                ClientStatusName = client.ClientStatus.ClientStatusName
            };
        }
    }
}
