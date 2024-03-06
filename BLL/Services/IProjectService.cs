using DAL.Entities;
using DataTask = DAL.Entities.Task;

namespace BLL.Services
{
    public interface IProjectService
    {
        public Task<IEnumerable<Project>> GetAllProjectAsync();
        public Task<Project> GetProjectByIdAsync(string id);
        public Task<IEnumerable<DataTask>> GetTasksFromProjectAsync(string id);
        public Task<DataTask> GetTaskByIdFromProject(string projectId, string taskId);

    }
}
