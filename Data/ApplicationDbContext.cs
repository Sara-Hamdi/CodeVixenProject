using Microsoft.EntityFrameworkCore;
using mvcProject.Models;
namespace mvcProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
