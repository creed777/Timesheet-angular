using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Interfaces;
using System.Diagnostics;

namespace API.Services
{
    public class ResourceDataService : IResourceDataService
    { 
        private ILogger<ResourceDataService> _logger { get; set; }
        private IHttpContextAccessor _httpContext { get; set; }
        private IDbContextFactory<DatabaseContext> _dbFactory { get; set; }

        public ResourceDataService(
            ILogger<ResourceDataService> logger,
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

        public async Task<ResourceModel> GetResourceByIdAsync(int resourceId)
        {
            await using var db = _dbFactory.CreateDbContext();

            try
            {
               var result = await db.Resource
                    .Where(p => p.ResourceId == resourceId)
                    .Include(x => x.ResourceType)
                    .Include(x => x.ResourceStatus)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if(result ==  null)
                {
                    return new ResourceModel();
                }
                return result;
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

        public async Task<List<ResourceModel>> GetResourcesByTypeAsync(int resourceTypeId)
        {
            if(resourceTypeId == 0)
                new ArgumentNullException(nameof(resourceTypeId));

            await using var db = _dbFactory.CreateDbContext();

            try
            {
                var result = await db.Resource
                    .Where(x => x.ResourceType.ResourceTypeId == resourceTypeId)
                    .Include(x => x.ResourceType)
                    .Include(x => x.ResourceStatus)
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

                Debug.WriteLine(ex.Message);
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
                var status = await db.ResourceStatus
                    .Where(x => x.ResourceStatusId == resource.ResourceStatus.ResourceStatusId)
                    .FirstOrDefaultAsync();
                
                var type = await db.ResourceTypes
                    .Where(x => x.ResourceTypeId == resource.ResourceType.ResourceTypeId)
                    .FirstOrDefaultAsync();

                resource.ResourceStatus = status;
                resource.ResourceType = type;

                await db.Resource.AddAsync(resource);
                var result = await db.SaveChangesAsync();
                return resource.ResourceId;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return -1;
            }
        }

        public async Task<int> DeleteResourceAsync(int resourceId)
        {
            await using var db = _dbFactory.CreateDbContext();

            if (resourceId == 0)
            {
                _logger.LogError(new ArgumentNullException(nameof(resourceId)).ToString());
                return -1;
            }

            var resource = await db.Resource.FindAsync(resourceId);
            if (resource == null)
                return -1;

            try
            {
                db.Resource.Remove(resource);
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
