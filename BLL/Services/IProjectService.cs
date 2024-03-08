using DAL.Entities;
using WebApi.Controllers;
using DataTask = DAL.Entities.Task;

namespace BLL.Services
{
    public interface IProjectService
    {
        public Task<IEnumerable<Project>> GetAllProjectAsync(QueryParameters parameters);
        public Task<Project> GetProjectByIdAsync(string id);
        public Task<IEnumerable<DataTask>> GetTasksFromProjectAsync(string id, QueryParameters parameters);
        public Task<DataTask> GetTaskByIdFromProject(string projectId, string taskId);

    }
}
