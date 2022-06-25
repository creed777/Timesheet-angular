using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Timesheet_angular.Models;

namespace Timesheet_angular.Services
{
    public class ClientDataService
    {
        private readonly IWebHostEnvironment _environment;
        private ILogger<ClientDataService> _logger { get; set; }
        public NavigationManager _navManager { get; set; }
        private DatabaseContext _dbContext;
        private readonly IHttpContextAccessor _httpContext;
        [Inject] private IDbContextFactory<DatabaseContext> _dbFactory { get; set; }
        public IDbContextFactory<DatabaseContext> DbFactory => _dbFactory;

        public ClientDataService(ILogger<ClientDataService> logger, IWebHostEnvironment env, IHttpContextAccessor accessor, IDbContextFactory<DatabaseContext> databaseFactory, NavigationManager navManger, DatabaseContext databaseContext, bool initialize = true)
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

        public async Task<List<ClientModel>> GetAllActiveClientsAsync()
        {
            await using var db = _dbFactory.CreateDbContext();
            var result = await db.Client
                .Where(c => c.ClientStatus.Id == 1)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }
    }
}
