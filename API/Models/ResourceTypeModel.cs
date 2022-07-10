using System.ComponentModel.DataAnnotations;
using API.DTO;

namespace API.Models
{
    public class ResourceTypeModel
    {
        [Key]
        public uint ResourceTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal? Cost { get; set; }

        public static implicit operator ResourceTypeDto(ResourceTypeModel resource)
        {
            return new ResourceTypeDto()
            {
                ResourceTypeId = resource.ResourceTypeId,
                Name = resource.Name,
                Cost = resource.Cost,                
            };
        }
    }
}
