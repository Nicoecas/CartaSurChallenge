namespace CartaSurChallenge.Entities
{
    public class Sucursal : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public List<Venta> Ventas { get; set; } = new List<Venta>();
        public List<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
