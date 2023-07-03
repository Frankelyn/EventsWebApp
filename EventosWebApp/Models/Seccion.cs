namespace EventosWebApp.Models
{
    public class Seccion
    {
        public int id_seccion { get; set; }
        public string? nombre_seccion { get; set; }
        public int capacidad_seccion { get; set; }
        public string? precio_asiento { get; set; }
        public int id_evento { get; set; }
    }
}
