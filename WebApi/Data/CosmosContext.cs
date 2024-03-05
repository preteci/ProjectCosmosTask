using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using DataTask = WebApi.Entities.Task;

namespace WebApi.Data
{
    public class CosmosContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public CosmosContext(DbContextOptions options) : base(options)
        {

        }

    }
}
