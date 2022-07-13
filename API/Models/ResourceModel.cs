using System.ComponentModel.DataAnnotations;
using API.DTO;

namespace API.Models
{
    /// <summary>
    /// Resource model
    /// </summary>
    public class ResourceModel
    {
        /// <summary>
        /// Resource record uniqe identifier
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Resource identifier
        /// </summary>
        public string? ResourceId { get; set; }
        /// <summary>
        /// Resource first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Resource last name
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Resource type object
        /// </summary>
        [Required]
        public ResourceTypeModel ResourceType { get; set; }
        /// <summary>
        /// Resource status object
        /// </summary>
        [Required]
        public ResourceStatusModel ResourceStatus { get; set; }

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
