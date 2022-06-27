using API.Interfaces;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Components;

namespace API.Domains
{
    public class ProjectDomain : IProjectDomain
    {
        private IProjectDataService _tds { get; set; }

        public ProjectDomain(IProjectDataService tds)
        {
            _tds = tds;
        }

        public async Task<List<ProjectModel>> GetAllProjects()
        {
            return await _tds.GetAllProjects();
        }

        public async Task<ProjectModel> GetProject(string projectId)
        {
            if(projectId == null)
                return new ProjectModel();

            return await _tds.GetProject(projectId);
        }

        public async Task<List<ProjectStatusModel>> GetProjectStatusList()
        {
            return await _tds.GetProjectStatusList();
        }

        public async Task<int> AddProject(ProjectModel project)
        {
            if(project == null)
                return 0;

            return await _tds.AddProject(project);
        }

        public async Task<bool> DeleteProject(string projectId)
        {
            if(projectId == null)
                return false;

            return await _tds.DeleteProject(projectId);
        }
    }
}
