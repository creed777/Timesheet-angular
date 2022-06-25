using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Timesheet_angular.Models;

namespace Timesheet_angular.Services
{
    public class TimesheetDataService
    {
        private readonly IWebHostEnvironment _environment;
        private ILogger<TimesheetDataService> _logger { get; set; }
        public NavigationManager _navManager { get; set; }
        private DatabaseContext _dbContext;
        private readonly IHttpContextAccessor _httpContext;
        [Inject] private IDbContextFactory<DatabaseContext> _dbFactory { get; set; }
        public IDbContextFactory<DatabaseContext> DbFactory => _dbFactory;

        public TimesheetDataService(ILogger<TimesheetDataService> logger, IWebHostEnvironment env, IHttpContextAccessor accessor, IDbContextFactory<DatabaseContext> databaseFactory, NavigationManager navManger, DatabaseContext databaseContext, bool initialize = true)
        {   
            _dbContext = databaseContext;
            _environment = env;
            _httpContext = accessor;
            _dbFactory = databaseFactory;
            _navManager = navManger;
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

        public async Task<List<ProjectModel>> GetProjectList()
        {
            await using var db = _dbFactory.CreateDbContext();
            return await db.Project
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ProjectStatusModel>> GetProjectStatusList()
        {
            await using var db = _dbFactory.CreateDbContext();
            return await db.projectStatus
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
