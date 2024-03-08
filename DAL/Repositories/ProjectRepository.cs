using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using DataTask = DAL.Entities.Task;

namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public CosmosContext _context;

        public ProjectRepository(CosmosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
           var projects = await _context.Projects.Include(t => t.Tasks).ToListAsync();
           return projects.AsQueryable();
        }
        public async Task<Project> GetByIdAsync(string id)
        {
            return await _context.Projects.Include(t => t.Tasks).FirstOrDefaultAsync(t => t.id == id);
        }

    }
}
