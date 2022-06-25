using API.Models;

namespace API.Interfaces
{
    public interface ITimesheetDataService
    {
        Task<ProjectModel> GetProject(string projectId);
        Task<List<ProjectModel>> GetAllProjects();
        Task<List<ProjectStatusModel>> GetProjectStatusList();
        Task<int> AddProject(ProjectModel project);
        Task<bool> DeleteProject(string projectId);
    }
}
