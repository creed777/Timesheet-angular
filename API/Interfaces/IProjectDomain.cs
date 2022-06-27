using API.Models;

namespace API.Interfaces
{
    public interface IProjectDomain
    {
        Task<List<ProjectModel>> GetAllProjects();
        Task<ProjectModel> GetProject(string projectId);
        Task<List<ProjectStatusModel>> GetProjectStatusList();
        Task<int> AddProject(ProjectModel project);
        Task<bool> DeleteProject(string projectId);
    }
}
