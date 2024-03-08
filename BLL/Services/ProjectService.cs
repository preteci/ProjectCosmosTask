using DAL.Repositories;
using DAL.Entities;
using DataTask = DAL.Entities.Task;
using BLL.Execptions;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace BLL.Services
{
    public class ProjectService: IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectAsync(QueryParameters parameters)
        {

            var projects = await _projectRepository.GetAllAsync();

            if(!string.IsNullOrEmpty(parameters.Name))
            {
                projects = projects.Where(p => p.Name.ToLowerInvariant().Contains(parameters.Name.ToLowerInvariant()));
            }

            var pagedProjects = projects
                           .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                           .Take(parameters.PageSize);
            return pagedProjects;
        }

        public async Task<Project> GetProjectByIdAsync(string id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                throw new ProjectNotFoundException($"Project with ID: {id} has not been found");
            }
            return project;
        }

        public async Task<IEnumerable<DataTask>> GetTasksFromProjectAsync(string id, QueryParameters parameters)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if(project == null)
            {
                throw new ProjectNotFoundException($"Project with ID: {id} has not been found");
            }

            var tasks = project.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(parameters.Name))
            {
                tasks = tasks.Where(p => p.Name.ToLowerInvariant().Contains(parameters.Name.ToLowerInvariant()));
            }

            var taskPages = tasks
                           .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                           .Take(parameters.PageSize);
            return taskPages;
            return taskPages;
        }

        public async Task<DataTask> GetTaskByIdFromProject(string projectId, string taskId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new ProjectNotFoundException($"Project with ID: {projectId} has not been found");
            }
            var task = project.Tasks.Find(t => t.id == taskId);
            if (task == null)
            {
                throw new TaskNotFoundException($"Task with ID: {taskId} has not been found");
            }
            return task;
        }


    }
}
