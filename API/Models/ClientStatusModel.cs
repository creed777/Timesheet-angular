using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ClientStatusModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClientStatusName { get; set; }
    }
}
