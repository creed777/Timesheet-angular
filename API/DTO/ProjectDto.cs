using API.Models;

namespace API.DTO
{
    public class ProjectDto
    {
        public string ProjectId { get; set; } 
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
        public string ClientId { get; set; }
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
        public uint ProjectStatusId { get; set; }

        public static implicit operator ProjectModel(ProjectDto project)
        {
            return new ProjectModel
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
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
                    Id = project.ProjectStatusId,

                }
            };
        }
    }
}
