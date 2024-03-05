using DataTask = WebApi.Entities.Task;

namespace WebApi.Entities
{
    public class Project
    {
        public string id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<DataTask>? Tasks { get; set; }
    }
}
