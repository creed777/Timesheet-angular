using API.Models;

namespace API.Interfaces
{
    public interface ITaskDataService
    {
        Task<List<TaskModel>> GetTasksByProjectIdAsync(int projectId);
        Task<TaskModel> GetTaskByIdAsync(int taskId);
        Task<int> UpdateTaskAsync(TaskModel task);
        Task<int> DeleteTaskAsync(int taskId);
        Task<List<TaskStatusModel>> GetTaskStatusListAsync();
        Task<List<TaskTimeModel>> GetTaskTimeEntriesAsync(int taskId);
        //Task<List<ResourceModel>> GetTaskResources(int taskId);
        Task<int> AddTaskAsync(TaskModel task);

    }
}
