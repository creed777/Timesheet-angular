using API.Models;

namespace API.Interfaces
{
    public interface ITaskDataService
    {
        Task<List<TaskModel>> GetTasksByProjectIdAsync(string projectId);
        Task<TaskModel> GetTaskByIdAsync(int taskId);
        Task<int> UpdateTask(TaskModel task);
        Task<int> DeleteTask(int taskId);
        Task<List<TaskStatusModel>> GetTaskStatusList();
        Task<List<TaskTimeModel>> GetTaskTimeEntries(int taskId);
        //Task<List<ResourceModel>> GetTaskResources(int taskId);
    }
}
