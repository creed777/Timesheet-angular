using API.Models;

namespace API.DTO
{
    public class TaskTimeDto
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Decimal Time { get; set; }

        public static implicit operator TaskTimeModel(TaskTimeDto task)
        {
            return new TaskTimeModel()
            {
                Id = task.Id,
                TaskId = task.TaskId,
                Time = task.Time
            };
        }
    }
}
