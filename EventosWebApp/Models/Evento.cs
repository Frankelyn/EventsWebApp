using System.ComponentModel.DataAnnotations;

namespace EventosWebApp.Models
{
    public class Evento
    {
        public int id_evento { get; set; }
        public string? nombre_evento { get; set; }
        public string? descripcion_evento { get; set; }
        public string? fecha_evento { get; set; }
        public string? hora_inicio { get; set; }
        public string? hora_finalizacion { get; set; }
        public string? fecha_finalizacion { get; set; }
        public int capacidad_total { get; set; }

    }
}
