namespace Maido.Models
{
    public class Mesa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado
        { get; set; } = "Libre";
        public bool Activa { get; set; } = true;
    }
}
