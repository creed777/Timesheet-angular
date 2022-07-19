using API.DTO;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class TaskTimeModel
    {
        [Key]
        public int TimeId { get; set; }
        public virtual Decimal Time { get; set; }
        public virtual TaskModel Task { get; set; }

        public static implicit operator TaskTimeDto(TaskTimeModel task)
        {
            return new TaskTimeDto()
            {
                Id = task.TimeId,
                Time = task.Time
            };
        }
    }
}
