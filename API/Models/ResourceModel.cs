using API.DTO;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ResourceModel
    {
        [Key]
        public int ResourceId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public ResourceTypeModel ResourceType { get; set; }
        public ResourceStatusModel ResourceStatus { get; set; }
        public ICollection<ProjectModel> Project { get; set; }
        public ICollection<TaskModel> Task { get; set; }
        

        public static implicit operator ResourceDto(ResourceModel resource)
        {
            return new ResourceDto()
            {
                ResourceId = resource.ResourceId,
                FirstName = resource.FirstName,
                LastName = resource.LastName,
                ResourceStatusName = resource.ResourceStatus.StatusName,
                ResourceTypeName = resource.ResourceType.Name
            };
        }
    }
}
