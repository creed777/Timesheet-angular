namespace API.Models
{
    public class TaskStatusModel
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public virtual ICollection<TaskModel> Task { get; set; }
    }
}
