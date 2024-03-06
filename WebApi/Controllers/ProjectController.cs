using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DataTask = DAL.Entities.Task;
using BLL.Execptions;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/projects")]

    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            var projects = await _projectService.GetAllProjectAsync();
            return Ok(projects);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProject(string Id)
        {
            try
            {
                var project = await _projectService.GetProjectByIdAsync(Id);
                return Ok(project);
            }
            catch (ProjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{Id}/tasks")]
        public async Task<IActionResult> GetAllTasksFromProject(string Id)
        {
            try
            {
                var tasks = await _projectService.GetTasksFromProjectAsync(Id);
                return Ok(tasks);
            }
            catch (ProjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
         }

        [HttpGet("{projectId}/tasks/{taskId}")]
        public async Task<IActionResult> GetTaskFromProject(string projectId, string taskId)
        {
            try
            {
                var task = await _projectService.GetTaskByIdFromProject(projectId, taskId);
                return Ok(task);
            }
            catch(ProjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(TaskNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
