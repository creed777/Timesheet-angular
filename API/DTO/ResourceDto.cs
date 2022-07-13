using API.Models;

namespace API.DTO
{

    public class ResourceDto
    {
        public string ResourceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResourceTypeName { get; set; }
        public string ResourceStatusName { get; set; }

        public static implicit operator ResourceModel(ResourceDto resource)
        {
            return new ResourceModel()
            {
                ResourceId = resource.ResourceId,
                FirstName = resource.FirstName,
                LastName = resource.LastName,
                ResourceType = new ResourceTypeModel()
                {
                    Name = resource.ResourceTypeName
                },

                ResourceStatus = new ResourceStatusModel()
                {
                    StatusName = resource.ResourceStatusName
                }
            };
        }
    }
}
