using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TaskDataService : ITaskDataService
    {
        private ILogger<TaskDataService> _logger { get; set; }
        private readonly IHttpContextAccessor _httpContext;
        private IDbContextFactory<DatabaseContext> _dbFactory { get; set; }

        public TaskDataService(
            ILogger<TaskDataService> logger, 
            IHttpContextAccessor httpContext, 
            IDbContextFactory<DatabaseContext> dbFactory, 
            bool initialize = true)
        {
            _logger = logger;
            _httpContext = httpContext;
            _dbFactory = dbFactory;

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

        public async Task<List<TaskModel>> GetTasksByProjectIdAsync(int projectId)
        {
            await using var db = _dbFactory.CreateDbContext();

            var project = db.Task
                .Where(x => x.Project.ProjectId == projectId)
                .Include(x => x.TaskStatus)
                .Include(x => x.Resource)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var result = await db.Task.Where(x => x.Project.ProjectId == project.Id)
                                             .AsNoTracking()
                                             .ToListAsync();

            return result;
        }

        public async Task<TaskModel> GetTaskByIdAsync(int taskId)
        {
            await using var db = _dbFactory.CreateDbContext();

            var result = await db.Task.Where(x => x.TaskId == taskId)
                                            .Include(x => x.TaskStatus)
                                            .Include(x => x.Resource)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();

            return result;

        }

        public async Task<int> UpdateTaskAsync(TaskModel task)
        {   
            await using var db = _dbFactory.CreateDbContext();

            try
            {
                var result = db.Task
                            .Where(x => x.TaskId == task.TaskId)
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

        public async Task<int> DeleteTaskAsync(int taskId)
        {

            await using var db = _dbFactory.CreateDbContext();
            var task = db.Task
                        .Where(x => x.TaskId == taskId)
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

        public async Task<List<TaskStatusModel>> GetTaskStatusListAsync()
            {
            await using var db = _dbFactory.CreateDbContext();
            var result = await db.TaskStatus
                            .ToListAsync();

            return result;

            }

        public async Task<List<TaskTimeModel>> GetTaskTimeEntriesAsync(int taskId)
        {
            await using var db = _dbFactory.CreateDbContext();
            var result = await db.TaskTime
                                .Include(x => x.Time)
                                .Where(x => x.Task.TaskId == taskId)
                                .ToListAsync();
            return result;
        }

        public async Task<int> AddTaskAsync(TaskModel task)
        {
            await using var db = _dbFactory.CreateDbContext();
            var addTask = db.Task.AddAsync(task);
            var result = await db.SaveChangesAsync();
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
