using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ProjectStatusModel
    {
        [Key]
        public uint Id { get; set; }
        [Required]
        public string StatusName { get; set; } = string.Empty;
    }
}
