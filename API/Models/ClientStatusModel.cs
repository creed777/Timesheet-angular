using API.DTO;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ClientStatusModel
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string ClientStatusName { get; set; }
        public virtual ICollection<ClientModel> Client { get; set; }
         
        public static implicit operator ClientStatusDto(ClientStatusModel clientStatusModel)
        {
            return new ClientStatusDto()
            {
                ClientStatusName = clientStatusModel.ClientStatusName
            };
        }
    }
}
