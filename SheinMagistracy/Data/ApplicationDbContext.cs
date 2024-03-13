using Microsoft.EntityFrameworkCore;
using SheinMagistracy.Models;

namespace SheinMagistracy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Subject> Subject {  get; set; }
        public DbSet<Exercise> Exercise { get; set; }
    }
}
