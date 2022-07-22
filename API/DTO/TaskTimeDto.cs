using API.Models;

namespace API.DTO
{
    public class TaskTimeDto
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Decimal Time { get; set; }

        public static implicit operator TaskTimeModel(TaskTimeDto taskTime)
        {
            return new TaskTimeModel()
            {
                Time = taskTime.Time,
                Task = new TaskModel()
                {
                   TaskId = taskTime.TaskId,
                }
            };
        }
    }
}
