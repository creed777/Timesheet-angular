using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ResourceTypeModel
    {
        [Key]
        public uint ResourceTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal? Cost { get; set; }
    }
}
