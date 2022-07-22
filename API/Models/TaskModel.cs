
using API.DTO;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace API.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public TaskStatusModel TaskStatus { get; set; }
        public ICollection<TaskTimeModel> TaskTime { get; set; }
        public ICollection<ResourceModel> Resource { get; set; }
        public ProjectModel Project { get; set; }
        public HierarchyId Level { get; set; }

        public static implicit operator TaskDto(TaskModel task)
        {
            return new TaskDto()
            {
                Id = task.TaskId,
                ProjectId = task.Project.ProjectId,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                EstimatedStartDate = task.EstimatedStartDate,
                EstimatedEndDate = task.EstimatedEndDate,
                ActualStartDate = task.ActualStartDate,
                ActualEndDate = task.ActualEndDate,
                TaskStatusName = task.TaskStatus.StatusName,
                Level = task.Level
            };
        }
    }

}
