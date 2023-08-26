using Microsoft.EntityFrameworkCore;
using NominaWeb.Models;

namespace NominaWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Profesor> Profesores { get; set; }
    }
}
