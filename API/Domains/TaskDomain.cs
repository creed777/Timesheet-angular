using API.Interfaces;
using API.Services;
using API.DTO;

namespace API.Domains
{
    public class TaskDomain : ITaskDomain
    {
        private ITaskDataService _tds { get; set; }
        public TaskDomain(ITaskDataService tds)
        {
            _tds = tds;
        }

        public async Task<List<TaskDto>> GetTasksByProjectIdAsync(int projectId)
        {
            var result = await _tds.GetTasksByProjectIdAsync(projectId);
            var taskDto = result.ConvertAll<TaskDto>(x => x);
            return taskDto;            
        }

        public async Task<TaskDto> GetTaskByIdAsync(int taskId)
        {
            var result = await _tds.GetTaskByIdAsync(taskId);
            var taskDto = result;
            return result;
        }

        public async Task<int> UpdateTaskAsync(TaskDto task)
        {
            var result = await _tds.UpdateTaskAsync(task);
            return result;
        }

        public async Task<int> DeleteTaskAsync(int taskId)
        {
            var result = await _tds.DeleteTaskAsync(taskId);
            return result;
        }

        public async Task<List<TaskTimeDto>> GetTaskTimeEntriesAsync(int taskId)
        {
            var result = await _tds.GetTaskTimeEntriesAsync(taskId);
            List<TaskTimeDto> taskDto = result.ConvertAll<TaskTimeDto>(x => x);
            return taskDto;
        }

        public async Task<int> AddTaskAsync(TaskDto task)
        {
            var taskModel = task;
            var result = await _tds.AddTaskAsync(taskModel);
            return result;
        }


    }
}
