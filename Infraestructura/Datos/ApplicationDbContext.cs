using System.Reflection;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Lugar> Lugar { get; set; } // Genera una tabla llamada Lugar
        public DbSet<Pais> Pais { get; set; } // Genera una tabla llamada Pais
        public DbSet<Categoria> Categoria { get; set; } // Genera una tabla llamada Categoria

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Encargado de crear las migraciones
        {
            base.OnModelCreating(modelBuilder); // Invoca al metodo base

            // Aplica las configuraciones de las entidades (Lugar, Pais, Categoria)
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
    }
}