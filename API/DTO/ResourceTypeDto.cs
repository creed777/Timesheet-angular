using API.Models;

namespace API.DTO
{
    public class ResourceTypeDto
    {
        public uint ResourceTypeId { get; set; }
        public string Name { get; set; }
        public decimal? Cost { get; set; }

        public static implicit operator ResourceTypeModel(ResourceTypeDto resource)
        {
            return new ResourceTypeModel()
            {
                ResourceTypeId = resource.ResourceTypeId,
                Name = resource.Name,
                Cost = resource.Cost
            };
        }
    }
}
