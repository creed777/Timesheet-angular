﻿
using API.DTO;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace API.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public virtual TaskStatusModel TaskStatus { get; set; }
        public virtual ICollection<TaskTimeModel> TaskTime { get; set; }
        public virtual ICollection<ResourceModel> Resource { get; set; }
        public int ProjectId { get; set; }
        public ProjectModel Project { get; set; }
        public HierarchyId Level { get; set; }

        public static implicit operator TaskDto(TaskModel task)
        {
            return new TaskDto()
            {
                Id = task.Id,
                ProjectId = task.ProjectId,
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
