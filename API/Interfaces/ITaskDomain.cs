using API.DTO;
using System.Collections.Generic;

namespace API.Interfaces
{
    public interface ITaskDomain
    {
        Task<List<TaskDto>> GetTasksByProjectIdAsync(string projectId);
        Task<TaskDto> GetTaskByIdAsync(int taskId);
        Task<int> UpdateTask(TaskDto task);
        Task<int> DeleteTask(int taskId);
    }
}
