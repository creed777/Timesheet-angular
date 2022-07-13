namespace API.Models
{
    public class TaskTimeModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Decimal Time { get; set; }
    }
}
