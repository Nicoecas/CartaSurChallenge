namespace CartaSurChallenge.Entities
{
    public class Empleado : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; } = default!;
        public List<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
