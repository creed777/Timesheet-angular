﻿using API.DTO;

namespace API.Models
{
    public class TaskTimeModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Decimal Time { get; set; }

        public static implicit operator TaskTimeDto(TaskTimeModel task)
        {
            return new TaskTimeDto()
            {
                Id = task.Id,
                TaskId = task.TaskId,
                Time = task.Time
            };
        }
    }
}
