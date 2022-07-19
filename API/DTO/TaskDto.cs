using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace API.DTO
{
    public class TaskDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string TaskStatusName { get; set; }
        public HierarchyId Level { get; set; }

        public static implicit operator TaskModel(TaskDto task)
        {
            return new TaskModel()
            {
                TaskId = task.Id,
                Project = new ProjectModel()
                {
                    ProjectId = task.ProjectId,
                },
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                EstimatedStartDate = task.EstimatedStartDate,
                EstimatedEndDate = task.EstimatedEndDate,
                ActualStartDate = task.ActualStartDate,
                ActualEndDate = task.ActualEndDate,
                TaskStatus = new TaskStatusModel()
                {
                    StatusName = task.TaskStatusName
                },
                Level = task.Level,
            };
        }
    }
}
