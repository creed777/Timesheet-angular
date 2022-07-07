using API.Models;
using API.DTO;

namespace API.Interfaces
{
    public interface IProjectDomain
    {
        Task<List<ProjectDto>> GetAllProjects();
        Task<ProjectDto> GetProject(string projectId);
        Task<List<ProjectStatusModel>> GetProjectStatusList();
        Task<int> AddProject(ProjectDto project);
        Task<bool> DeleteProject(string projectId);
    }
}
