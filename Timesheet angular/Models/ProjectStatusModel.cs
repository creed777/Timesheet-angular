using System.ComponentModel.DataAnnotations;

namespace Timesheet_angular.Models
{
    public class ProjectStatusModel
    {
        [Key]
        public uint Id { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }
}
