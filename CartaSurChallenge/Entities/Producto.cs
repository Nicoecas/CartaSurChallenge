namespace CartaSurChallenge.Entities
{
    public class Producto : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public double Precio { get; set; } = 0;
    }
}
