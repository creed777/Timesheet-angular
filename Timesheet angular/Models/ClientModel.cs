using System.ComponentModel.DataAnnotations;

namespace Timesheet_angular.Models
{
    public class ClientModel
    {
        [Key]
        public uint ClientId { get; set; }
        [Required]
        public string ClientName { get; set; } = default!;
        [Required]
        public string ClientDescription { get; set; } = default!;
        public virtual ClientStatusModel ClientStatus { get; set; } = new ClientStatusModel();
    }
}
