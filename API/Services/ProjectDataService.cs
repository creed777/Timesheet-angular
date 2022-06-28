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

        public async Task<ProjectModel> GetProject(string projectId)
        {
            await using var db = _dbFactory.CreateDbContext();
            return await db.Project
                .AsNoTracking()
                .Where(p => p.ProjectId == projectId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ProjectModel>> GetAllProjects()
        {
            await using var db = _dbFactory.CreateDbContext();
            return await db.Project
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
            await using var db = _dbFactory.CreateDbContext();

            if (project == null)
                new ArgumentNullException(nameof(project));

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

        public async Task<bool> DeleteProject(string projectId)
        {
            await using var db = _dbFactory.CreateDbContext();

            if (string.IsNullOrEmpty(projectId))
            {
                _logger.LogError(new ArgumentNullException(nameof(projectId)).ToString());
                return false;
            }

            var projectModel = await db.Project.FindAsync(projectId);
            if (projectModel == null)
                return false;

            try
            {
                db.Project.Remove(projectModel);
                await db.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException ex)
            {
                _logger.LogCritical(ex.Message);
                return false;
            }
        }
    }
}
