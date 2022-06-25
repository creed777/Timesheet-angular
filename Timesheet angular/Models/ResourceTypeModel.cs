using System.ComponentModel.DataAnnotations;

namespace Timesheet_angular.Models
{
    public class ResourceTypeModel
    {
        [Key]
        public uint ResourceTypeId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
