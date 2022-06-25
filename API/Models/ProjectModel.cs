using System.ComponentModel.DataAnnotations;

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
        public virtual ClientModel Client { get; set; } = new ClientModel();
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
        public virtual ProjectStatusModel ProjectStatus { get; set; } = new ProjectStatusModel();
    }
}
