using System.ComponentModel.DataAnnotations;
using API.DTO;

namespace API.Models
{
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string ClientName { get; set; } = default!;
        [Required]
        public string ClientDescription { get; set; } = default!;
        public virtual ClientStatusModel ClientStatus { get; set; } = new ClientStatusModel();

        public static implicit operator ClientDto(ClientModel client)
        {
            return new ClientDto()
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                ClientDescription = client.ClientDescription,
                ClientStatusId = client.ClientStatus.Id
            };
        }
    }
}
