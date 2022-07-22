using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ResourceStatusModel
    {
        [Key]
        public uint ResourceStatusId { get; set; }
        [Required]
        public string StatusName { get; set; }
        public virtual ICollection<ResourceModel> Resource { get; set; }
    }
}
