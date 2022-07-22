using API.Models;
using API.DTO;

namespace API.Interfaces
{
    public interface IProjectDomain
    {
        Task<List<ProjectDto>> GetAllProjects();
        Task<ProjectDto> GetProject(int projectId);
        Task<List<ProjectStatusModel>> GetProjectStatusList();
        Task<int> AddProject(ProjectDto project);
        Task<int> DeleteProject(int projectId);
    }
}
