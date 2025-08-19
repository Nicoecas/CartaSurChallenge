using CartaSurChallenge.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CartaSurChallenge.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedsContext(this ModelBuilder modelBuilder)
        {
            var fixedDate = new DateTime(2025, 8, 19, 0, 0, 0);
            // ====== Sucursal ======
            modelBuilder.Entity<Sucursal>().HasData(
                new Sucursal
                {
                    Id = 1,
                    Nombre = "Sucursal Centro",
                    Direccion = "Av. Corrientes 1234",
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                }
            );

            // ====== Empleados ======
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    Id = 1,
                    SucursalId = 1,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                }
            );

            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    Id = 2,
                    SucursalId = 1,
                    Nombre = "Enrique",
                    Apellido = "Rodriguéz",
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                }
            );

            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    Id = 3,
                    SucursalId = 1,
                    Nombre = "Mariano",
                    Apellido = "Pérez",
                    Activo = false,
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                }
            );

            // ====== Clientes ======
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Dni = "12345678",
                    Nombre = "Carlos López",
                    DireccionEnvio = "Calle Falsa 123",
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                },
                new Cliente
                {
                    Id = 2,
                    Dni = "87654321",
                    Nombre = "María González",
                    DireccionEnvio = "Av. San Martín 456",
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                }
            );

            // ====== Productos ======
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Silla",
                    Precio = 1000,
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Mesa",
                    Precio = 3000,
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                }
            );

            // ====== Ventas ======
            DateTime fechaCompartida = new DateTime(2025, 8, 19, 10, 0, 0); // misma fecha para 2 ventas
            DateTime fechaDiferente = new DateTime(2025, 8, 20, 15, 30, 0);

            modelBuilder.Entity<Venta>().HasData(
                new Venta
                {
                    Id = 1,
                    FechaVenta = fechaCompartida,
                    ImporteTotal = 2000, // 2 x Silla (1000)
                    ClienteId = 1,
                    EmpleadoId = 1,
                    SucursalId = 1,
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                },
                new Venta
                {
                    Id = 2,
                    FechaVenta = fechaCompartida,
                    ImporteTotal = 3000, // 1 x Mesa (3000)
                    ClienteId = 2,
                    EmpleadoId = 1,
                    SucursalId = 1,
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate
                },
                new Venta
                {
                    Id = 3,
                    FechaVenta = fechaDiferente,
                    ImporteTotal = 4000, // 1 x Mesa (3000) + 1 x Silla (1000)
                    ClienteId = 2,
                    EmpleadoId = 1,
                    SucursalId = 1,
                    CreatedDate = fixedDate,
                    UpdatedDate = fixedDate 
                }
            );

            // ====== VentaProducto ======
            modelBuilder.Entity<VentaProducto>().HasData(
                // Venta 1 - Cliente 1
                new { VentaId = 1, ProductoId = 1, Cantidad = 2 },

                // Venta 2 - Cliente 2
                new { VentaId = 2, ProductoId = 2, Cantidad = 1 },

                // Venta 3 - Cliente 2
                new { VentaId = 3, ProductoId = 1, Cantidad = 1 },
                new { VentaId = 3, ProductoId = 2, Cantidad = 1 }
            );

        }
    }
}
