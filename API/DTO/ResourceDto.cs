using API.Models;

namespace API.DTO
{

    public class ResourceDto
    {
        public int ResourceId { get; set; }
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

    public class CreateResourceDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResourceType { get; set; }
        public string ResourceStatus { get; set; }

        public static implicit operator ResourceModel(CreateResourceDto resource)
        {
            return new ResourceModel()
            {
                FirstName = resource.FirstName,
                LastName = resource.LastName,
                ResourceType = new ResourceTypeModel()
                {
                    Name = resource.ResourceType
                },

                ResourceStatus = new ResourceStatusModel()
                {
                    StatusName = resource.ResourceStatus
                }
            };
        }
    }
}
