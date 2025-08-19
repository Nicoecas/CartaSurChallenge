namespace CartaSurChallenge.Entities
{
    public class Venta : BaseEntity
    {
        public DateTime FechaVenta { get; set; }
        public double ImporteTotal { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = default!;

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; } = default!;

        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; } = default!;

        public List<VentaProducto> VentaProductos { get; set; } = new List<VentaProducto>();
    }
}
