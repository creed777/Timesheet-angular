using System.ComponentModel.DataAnnotations;

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
    }
}
