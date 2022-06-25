using System.ComponentModel.DataAnnotations;

namespace Timesheet_angular.Models
{
    public class ResourceModel
    {
        [Key]
        public uint ResourceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ResourceTypeModel ResourceTypeId { get; set; }
    }
}
