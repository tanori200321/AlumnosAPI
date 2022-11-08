using AlumnosAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlumnosAPI.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Alumno> Alumnos { get; set; }
    }
}
