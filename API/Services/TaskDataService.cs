using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TaskDataService : ITaskDataService
    {
        private ILogger<ClientDataService> _logger { get; set; }
        private readonly IHttpContextAccessor _httpContext;
        private IDbContextFactory<DatabaseContext> _dbFactory { get; set; }

        public TaskDataService(ILogger<ClientDataService> logger, IHttpContextAccessor httpContext, IDbContextFactory<DatabaseContext> dbFactory)
        {
            _logger = logger;
            _httpContext = httpContext;
            _dbFactory = dbFactory;

            Init();
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

        public async Task<List<TaskModel>> GetTasksByProjectIdAsync(string projectId)
        {
            await using var db = _dbFactory.CreateDbContext();

            var project = db.Project
                .Where(x => x.ProjectId == projectId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var result = await db.Task.Where(x => x.ProjectId == project.Id)
                                             .AsNoTracking()
                                             .ToListAsync();

            return result;
        }

        public async Task<TaskModel> GetTaskByIdAsync(int taskId)
        {
            await using var db = _dbFactory.CreateDbContext();

            var result = await db.Task.Where(x => x.Id == taskId)
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync();

            return result;

        }

        public async Task<int> UpdateTask(TaskModel task)
        {
            await using var db = _dbFactory.CreateDbContext();

            try
            {
                var result = db.Task
                            .Where(x => x.Id == task.Id)
                            .FirstOrDefaultAsync();

                db.Task.Update(task);
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return -1;
            }
        }

        public async Task<int> DeleteTask(int taskId)
        {

            await using var db = _dbFactory.CreateDbContext();
            var task = db.Task
                        .Where(x => x.Id == taskId)
                        .FirstOrDefaultAsync();

            try
            {
                db.Remove(task);
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return -1;
            }

        }

        public async Task<List<TaskStatusModel>> GetTaskStatusList()
            {
            await using var db = _dbFactory.CreateDbContext();
            var result = await db.TaskStatus
                            .ToListAsync();

            return result;

            }

        public async Task<List<TaskTimeModel>> GetTaskTimeEntries(int taskId)
        {
            await using var db = _dbFactory.CreateDbContext();
            var result = await db.TaskTime
                                .Where(x => x.TaskId == taskId)
                                .ToListAsync();
            return result;
        }

        //public async Task<List<ResourceModel>> GetTaskResources(int taskId)
        //{
        //    await using var db = _dbFactory.CreateDbContext();
        //    var result = await db.Resource
        //                        .Join(db.TaskResource, 
        //                        db.Resource => db.Resource.id)
        //                        .Where(x => x.TaskId == taskId)
        //                        .ToListAsync();
        //    return result;
        //}
    }
}
