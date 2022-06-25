using System.ComponentModel.DataAnnotations;

namespace Timesheet_angular.Models
{
    public class ClientStatusModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClientStatusName { get; set; }
    }
}
