using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Interfaces;

namespace API.Services
{
    public class ProjectDataService : IProjectDataService
    {
        private ILogger<ProjectDataService> _logger { get; set; }
        private IHttpContextAccessor _httpContext { get; set; }
        private IDbContextFactory<DatabaseContext> _dbFactory { get; set; }

        public ProjectDataService(
            ILogger<ProjectDataService> logger, 
            IHttpContextAccessor accessor, 
            IDbContextFactory<DatabaseContext> databaseFactory, 
            bool initialize = true)
        {
            _httpContext = accessor;
            _dbFactory = databaseFactory;
            _logger = logger;

            if (initialize)
            {
                Init();
            }
        }

        public void Init()
        {

            var user = _httpContext.HttpContext.User.Identity;

            if (user != null && user.IsAuthenticated)
            {
                var username = user.Name;
                using var db = _dbFactory.CreateDbContext();
            }

        }

        public async Task<ProjectModel> GetProject(int projectId)
        {
            await using var db = _dbFactory.CreateDbContext();
            var result = await db.Project
                .Include(x => x.ProjectStatus)
                .Include(x => x.Client)
                .Include(x => x.Task)
                .AsNoTracking()
                .Where(p => p.ProjectId == projectId)
                .FirstOrDefaultAsync();

            if(result != null)
            {
                return result;
            }
            else
            {
                return new ProjectModel();
            }
        }

        public async Task<List<ProjectModel>> GetAllProjects()
        {
            await using var db = _dbFactory.CreateDbContext();
            return await db.Project
                .Include(x => x.ProjectStatus)
                .Include(x => x.Client)
                .Include(x => x.Task)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ProjectStatusModel>> GetProjectStatusList()
        {
            await using var db = _dbFactory.CreateDbContext();
            return await db.ProjectStatus
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> AddProject(ProjectModel project)
        {
            if (project == null)
                new ArgumentNullException(nameof(project));

            await using var db = _dbFactory.CreateDbContext();
            ProjectStatusModel status = await db.ProjectStatus.FirstOrDefaultAsync(x => x.Id == project.ProjectStatus.Id);
            ClientModel client = await db.Client.FirstOrDefaultAsync(x => x.ClientId == project.Client.ClientId);
            project.ProjectStatus = status;
            project.Client = client;

            try
            {
                await db.Project.AddAsync(project);
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return -1;
            }
        }

        public async Task<int> DeleteProject(int projectId)
        {
            await using var db = _dbFactory.CreateDbContext();

            if (projectId == 0)
            {
                _logger.LogError(new ArgumentNullException(nameof(projectId)).ToString());
                return -1;
            }

            var projectModel = await db.Project.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (projectModel == null)
                return -1;

            try
            {
                db.Project.Remove(projectModel);
                return await db.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                _logger.LogCritical(ex.Message);
                return -1;
            }
        }
    }
}
