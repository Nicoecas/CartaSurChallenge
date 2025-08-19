using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CartaSurChallenge.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionEnvio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImporteTotal = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaProductos",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaProductos", x => new { x.VentaId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_VentaProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaProductos_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CreatedDate", "DireccionEnvio", "Dni", "Nombre", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calle Falsa 123", "12345678", "Carlos López", new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Av. San Martín 456", "87654321", "María González", new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CreatedDate", "Nombre", "Precio", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silla", 1000.0, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesa", 3000.0, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sucursales",
                columns: new[] { "Id", "CreatedDate", "Direccion", "Nombre", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Av. Corrientes 1234", "Sucursal Centro", new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Activo", "Apellido", "CreatedDate", "Nombre", "SucursalId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, true, "Pérez", new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, "Rodriguéz", new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enrique", 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, false, "Pérez", new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariano", 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "ClienteId", "CreatedDate", "EmpleadoId", "FechaVenta", "ImporteTotal", "SucursalId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 8, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), 2000.0, 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 8, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), 3000.0, 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 8, 20, 15, 30, 0, 0, DateTimeKind.Unspecified), 4000.0, 1, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "VentaProductos",
                columns: new[] { "ProductoId", "VentaId", "Cantidad" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 1 },
                    { 1, 3, 1 },
                    { 2, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SucursalId",
                table: "Empleados",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProductos_ProductoId",
                table: "VentaProductos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EmpleadoId",
                table: "Ventas",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_SucursalId",
                table: "Ventas",
                column: "SucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentaProductos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
