using Microsoft.EntityFrameworkCore;
using PortafoliosApp.Domain.Models;

namespace FamiliesApp.Domain.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Portafolio> Portafolios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ActividadUsuarios> ActividadUsuarios { get; set; }
    }
}
