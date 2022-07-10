using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Interfaces;

namespace API.Services
{
    public class ResourceDataService : IResourceDataService
    { 
        private ILogger<ProjectDataService> _logger { get; set; }
        private IHttpContextAccessor _httpContext { get; set; }
        private IDbContextFactory<DatabaseContext> _dbFactory { get; set; }

        public ResourceDataService(
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

        public async Task<ResourceModel> GetResourceByIdAsync(string resourceId)
        {
            await using var db = _dbFactory.CreateDbContext();

            try
            {
                return await db.ProjectResources
                    .Where(p => p.ResourceId == resourceId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new ResourceModel();
            }
        }

        public async Task<List<ResourceTypeModel>> GetResourceTypeList()
        {
            try
            {
                await using var db = _dbFactory.CreateDbContext();

                return await db.ResourceTypes
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new List<ResourceTypeModel>();
            }
        }

        public async Task<List<ResourceModel>> GetResourcesByTypeAsync(string resourceTypeName)
        {
            if(string.IsNullOrEmpty(resourceTypeName))
                new ArgumentNullException(nameof(resourceTypeName));

            await using var db = _dbFactory.CreateDbContext();

            try
            {
                var result = await db.ProjectResources
                    .Where(x => x.ResourceType.Name == resourceTypeName)
                    .AsNoTracking()
                    .ToListAsync();

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new List<ResourceModel>();
                }
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return new List<ResourceModel>();
            }
        }

        public async Task<int> AddResourceAsync(ResourceModel resource)
        {
            await using var db = _dbFactory.CreateDbContext();

            if (resource == null)
                new ArgumentNullException(nameof(resource));

            try
            {
                await db.ProjectResources.AddAsync(resource);
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return -1;
            }
        }

        public async Task<int> DeleteResourceAsync(string resourceId)
        {
            await using var db = _dbFactory.CreateDbContext();

            if (string.IsNullOrEmpty(resourceId))
            {
                _logger.LogError(new ArgumentNullException(nameof(resourceId)).ToString());
                return -1;
            }

            var resource = await db.ProjectResources.FindAsync(resourceId);
            if (resource == null)
                return -1;

            try
            {
                db.ProjectResources.Remove(resource);
                return await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogCritical(ex.Message);
                return -1;
            }
        }
    }
}
