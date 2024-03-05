using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;
using DataTask = WebApi.Entities.Task;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("apii/[controller]")]

    public class ProjectController : ControllerBase
    {
        private readonly CosmosContext _context;

        public ProjectController(CosmosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetAllProject()
        {
            return await _context.Projects.Include(t => t.Tasks).ToListAsync();

        }

        [HttpGet("{Id}")]
        public async Task<Project> GetProject(string Id)
        {
            return await _context.Projects.FirstOrDefaultAsync(t => t.id == Id);

        }

        [HttpGet("{Id}/tasks")]
        public async Task<IEnumerable<DataTask>> GetAllTasksFromProject(string Id)
        {
            var project = await _context.Projects.Include(t => t.Tasks).FirstOrDefaultAsync(t => t.id == Id);
            var tasks = project.Tasks.ToList();
            return tasks;
        }

        [HttpGet("{projectId}/tasks/{taskId}")]
        public async Task<DataTask> GetTaskFromProject(string projectId, string taskId)
        {
            var project = await _context.Projects.Include(t => t.Tasks).FirstOrDefaultAsync(t => t.id == projectId);
            var task = project.Tasks.Find(t => t.id == taskId);
            return task;
        }

    }
}
