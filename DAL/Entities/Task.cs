using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    [Owned]
    public class Task
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHOld
    }
}
