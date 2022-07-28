using Microsoft.EntityFrameworkCore;
using Nevus.Models;


namespace Nevus.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { 
            
        
        }


        public DbSet<Ciudad> Ciudad  { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
    }
}
