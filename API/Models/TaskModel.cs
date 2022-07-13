using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public ICollection<TaskStatusModel> TaskStatus { get; set; }
        public ICollection<TaskTimeModel> TaskTime { get; set; }
        public ICollection<TaskResourceModel> TaskResource { get; set; }
        public HierarchyId Level { get; set; }
    }
}
