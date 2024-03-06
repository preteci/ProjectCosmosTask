using DAL.Entities;
using DataTask = DAL.Entities.Task;

namespace DAL.Repositories
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Project>> GetAllAsync();
        public Task<Project> GetByIdAsync(string id);
    }
}
