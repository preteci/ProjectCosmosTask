using DataTask = DAL.Entities.Task;

namespace DAL.Entities
{
    public class Project
    {
        public string id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<DataTask>? Tasks { get; set; }
        public ProjectStatus Status { get; set; }
    }
    public enum ProjectStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold
    }
}
