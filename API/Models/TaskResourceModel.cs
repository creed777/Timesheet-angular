using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class TaskResourceModel
    {
        [Key]
        public int TaskId { get; set; }
        public int ResourceId { get; set; }
    }
}
