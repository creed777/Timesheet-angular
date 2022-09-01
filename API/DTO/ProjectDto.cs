using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class ProjectDto
    {
        public uint ProjectId { get; set; } 
        public string ProjectSn { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
        public uint ClientId { get; set; }
        public string ClientName { get; set; }
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
        public string ProjectStatus { get; set; }

        public static implicit operator ProjectModel(ProjectDto project)
        {
            return new ProjectModel
            {
                ProjectId = (int)project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectSn = project.ProjectSn,
                ProjectDescription = project.ProjectDescription,
                Client = new ClientModel()
                {
                    ClientId = (int)project.ClientId,
                    ClientName = project.ClientName
                },
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
                ProjectStatus = new ProjectStatusModel()
                {
                    StatusName = project.ProjectStatus
                }
            };
        }
    }

    public class CreateProjectDto
    {
        [Required(ErrorMessage = "Project short name is required")]
        public string ProjectSn { get; set; }
        [Required(ErrorMessage = "Project name is required")]
        public string ProjectName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Project description is required")]
        public string ProjectDescription { get; set; } = string.Empty;
        [Required(ErrorMessage = "Client Id is required")]
        public int ClientId { get; set; }
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
        [Required(ErrorMessage = "Project Status is required")]
        public string ProjectStatus { get; set; }

        public static implicit operator ProjectModel(CreateProjectDto project)
        {
            return new ProjectModel
            {
                ProjectName = project.ProjectName,
                ProjectSn = project.ProjectSn,
                ProjectDescription = project.ProjectDescription,
                Client = new ClientModel()
                {
                    ClientId = project.ClientId,
                },
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
                ProjectStatus = new ProjectStatusModel()
                {
                    StatusName = project.ProjectStatus
                }
            };
        }
    }
}
