using CRUDWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
