using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Interfaces;

namespace API.Services
{
    public class TimesheetDataService : ITimesheetDataService
    {
        private ILogger<TimesheetDataService> _logger { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        [Inject] private IHttpContextAccessor _httpContext { get; set; }
        [Inject] private IDbContextFactory<DatabaseContext> _dbFactory { get; set; }
        public IDbContextFactory<DatabaseContext> DbFactory => _dbFactory;

        public TimesheetDataService(
            ILogger<TimesheetDataService> logger, 
            IHttpContextAccessor accessor, 
            IDbContextFactory<DatabaseContext> databaseFactory, 
            //NavigationManager navManger, 
            bool initialize = true)
        {
            _httpContext = accessor;
            _dbFactory = databaseFactory;
            //_navManager = navManger;
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
                new ArgumentNullException(nameof(projectId));

            var projectModel = await db.Project.FindAsync(projectId);
            if (projectModel == null)
            {
                return false;
            }

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
