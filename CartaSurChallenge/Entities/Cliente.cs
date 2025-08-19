namespace CartaSurChallenge.Entities
{
    public class Cliente : BaseEntity
    {
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty ;
        public string DireccionEnvio { get; set; } = string.Empty;
        public List<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
