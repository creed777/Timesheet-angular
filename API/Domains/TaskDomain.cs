using API.Interfaces;
using API.Services;
using API.DTO;

namespace API.Domains
{
    public class TaskDomain : ITaskDomain
    {
        private ITaskDataService _tds { get; set; }
        public TaskDomain(TaskDataService tds)
        {
            _tds = tds;
        }

        public async Task<List<TaskDto>> GetTasksByProjectIdAsync(string projectId)
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

        public async Task<int> UpdateTask(TaskDto task)
        {
            var result = await _tds.UpdateTask(task);
            return result;
        }

        public async Task<int> DeleteTask(int taskId)
        {
            var result = await _tds.DeleteTask(taskId);
            return result;
        }

        public async Task<List<TaskTimeDto>> GetTaskTimeEntries(int taskId)
        {
            var result = await _tds.GetTaskTimeEntries(taskId);
            List<TaskTimeDto> taskDto = result.ConvertAll<TaskTimeDto>(x => x);
            return taskDto;
        }

       
    }
}
