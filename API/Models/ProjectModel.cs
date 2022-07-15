﻿using System.ComponentModel.DataAnnotations;
using API.DTO;

namespace API.Models
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProjectId { get; set; }  
        [Required]
        public string ProjectName { get; set; } = string.Empty;
        [Required]
        public string ProjectDescription { get; set; } = string.Empty;
        [Required]
        public ClientModel Client { get; set; }
        public uint? DivisionId { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public uint? ProjectManagerId { get; set; }
        public decimal? EstimatedTotalHours { get; set; }
        public decimal? ActualTotalHours { get; set; }
        public decimal? EstimatedLaborCost { get; set; }
        public decimal? ActualLaborCost { get; set; }
        public decimal? EstimatedMaterialCost { get; set; }
        public decimal? ActualMaterialCost { get; set; }
        public ProjectStatusModel ProjectStatus { get; set; }
        public ICollection<TaskModel> Task { get; set; }
        public ICollection<ResourceModel> Resource { get; set; }

        public static implicit operator ProjectDto(ProjectModel project)
        {
            return new ProjectDto
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,
                ClientId = project.Client.ClientId,
                DivisionId = project.DivisionId,
                EstimatedStartDate = project.EstimatedStartDate,
                EstimatedEndDate = project.EstimatedEndDate,
                ActualStartDate = project.ActualStartDate,
                ActualEndDate = project.ActualEndDate,
                ProjectManagerId = project.ProjectManagerId,
                EstimatedTotalHours = project.EstimatedTotalHours,
                ActualTotalHours = project.ActualTotalHours,
                ActualLaborCost = project.ActualLaborCost,
                EstimatedMaterialCost = project.EstimatedMaterialCost,
                ActualMaterialCost = project.EstimatedMaterialCost,
                ProjectStatusId = project.ProjectStatus.Id
            };
        }
    }
}
