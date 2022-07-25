using API.Interfaces;
using API.Models;
using API.DTO;

namespace API.Domains
{
    public class ProjectDomain : IProjectDomain
    {
        private IProjectDataService _tds { get; set; }
        private IClientDataServices _cds { get; set; }

        public ProjectDomain(IProjectDataService tds, IClientDataServices cds)
        {
            _tds = tds;
            _cds = cds;
        }

        public async Task<List<ProjectDto>> GetAllProjects()
        {
            var dbProject = await _tds.GetAllProjects();

            List<ProjectDto> result = dbProject.ConvertAll<ProjectDto>(x => x);
            return result;
        }

        public async Task<ProjectDto> GetProject(int projectId)
        {
            if(projectId == 0)
                return new ProjectDto();

            var result = await _tds.GetProject(projectId);
            ProjectDto dto = result;
            return dto;
        }

        public async Task<List<ProjectStatusModel>> GetProjectStatusList()
        {
            return await _tds.GetProjectStatusList();
        }

        public async Task<int> AddProject(CreateProjectDto createProjectDto)
        {
            if(createProjectDto == null)
                return -1;

            ProjectModel projectModel = createProjectDto;
            return await _tds.AddProject(projectModel);
        }

        public async Task<int> DeleteProject(int projectId)
        {
            if(projectId == 0)
                return -1;

            return await _tds.DeleteProject(projectId);
        }
    }
}
