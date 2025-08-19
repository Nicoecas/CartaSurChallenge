using CartaSurChallenge.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Transactions;

namespace CartaSurChallenge.Data
{
    public class CartaSurChallengeDbContext : DbContext
    {
        public CartaSurChallengeDbContext()
        {
        }

        public CartaSurChallengeDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VentaProducto>(entity =>
            {
                entity.HasKey(vp => new { vp.VentaId, vp.ProductoId }); 
            });
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Sucursal)
                .WithMany(s => s.Empleados) // Asume que Sucursal tiene una colección de Empleados
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.SeedsContext();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaProducto> VentaProductos { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
