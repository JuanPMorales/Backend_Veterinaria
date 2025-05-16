using Microsoft.EntityFrameworkCore;
using Veterinaria.API.Models;

namespace Veterinaria.API.Data
{
    public class VeterinariaDbContext : DbContext
    {
        public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> options) : base(options)
        {
        }

        // DbSets por cada entidad
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<CitaProducto> CitaProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clave compuesta para CitaProducto
            modelBuilder.Entity<CitaProducto>()
                .HasKey(cp => new { cp.IdCita, cp.IdProducto });

            // Relación CitaProducto → Cita
            modelBuilder.Entity<CitaProducto>()
                .HasOne(cp => cp.Cita)
                .WithMany(c => c.CitaProductos)
                .HasForeignKey(cp => cp.IdCita);

            // Relación CitaProducto → Producto
            modelBuilder.Entity<CitaProducto>()
                .HasOne(cp => cp.Producto)
                .WithMany(p => p.CitaProductos)
                .HasForeignKey(cp => cp.IdProducto);
        }
    }
}
