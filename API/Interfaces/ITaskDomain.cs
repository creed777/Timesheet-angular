using API.DTO;
using System.Collections.Generic;

namespace API.Interfaces
{
    public interface ITaskDomain
    {
        Task<List<TaskDto>> GetTasksByProjectIdAsync(int projectId);
        Task<TaskDto> GetTaskByIdAsync(int taskId);
        Task<int> UpdateTaskAsync(TaskDto task);
        Task<int> DeleteTaskAsync(int taskId);
        Task<List<TaskTimeDto>> GetTaskTimeEntriesAsync(int taskId);
        Task<int> AddTaskAsync(TaskDto task);
    }
}
