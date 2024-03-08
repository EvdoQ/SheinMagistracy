using Microsoft.EntityFrameworkCore;
using SheinMagistracy.Models;

namespace SheinMagistracy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        DbSet<Subject> Subject {  get; set; }
    }
}
