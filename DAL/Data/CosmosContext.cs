using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class CosmosContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public CosmosContext(DbContextOptions options) : base(options)
        { 

        }

    }
}
