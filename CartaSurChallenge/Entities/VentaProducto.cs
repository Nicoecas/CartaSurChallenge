namespace CartaSurChallenge.Entities
{
    public class VentaProducto
    {
        public int VentaId { get; set; }
        public Venta Venta { get; set; } = default!;

        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = default!;

        public int Cantidad { get; set; } = 0;
    }
}
