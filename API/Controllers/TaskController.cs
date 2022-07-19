using API.Interfaces;
using API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class TaskController : Controller
    {

        private readonly ITaskDomain _taskDomain;

        public TaskController(ITaskDomain taskDomain)
        {
            _taskDomain = taskDomain;
        }

        [HttpGet("{projectId}")]
        public async Task<List<TaskDto>> GetTasksByProjectIdAsync(int projectId)
        {
            var result = await _taskDomain.GetTasksByProjectIdAsync(projectId);
            return result;
        }

        [HttpGet("{taskId}")]
        public async Task<TaskDto> GetTaskById(int taskId)
        {
            var result = await _taskDomain.GetTaskByIdAsync(taskId);
            return result;
        }

        [HttpPost("{task}")]
        public async Task<int> UpdateTask(TaskDto task)
        {
            var result = await _taskDomain.UpdateTaskAsync(task);
            return result;
        }

        [HttpDelete("{taskId}")]
        public async Task<int> DeleteTask(int taskId)
        {
            var result = await _taskDomain.DeleteTaskAsync(taskId);
            return result;
        }

        [HttpGet("{taskId}")]
        public async Task<List<TaskTimeDto>> GetTaskTimeEntries(int taskId)
        {
            var result = await _taskDomain.GetTaskTimeEntriesAsync(taskId);
            return result;
        }

        [HttpGet("{task}")]
        public async Task<int> AddTaskAsync(TaskDto task)
        {
            var result = await _taskDomain.AddTaskAsync(task);
            return result;
        }

    }
}
