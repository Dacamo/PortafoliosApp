using System;
using System.ComponentModel.DataAnnotations;

namespace PortafoliosApp.Commands
{
    public class CrearActividad
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Tutor { get; set; }
        [Required]
        public int Puntaje { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int PortafolioId { get; set; }
    }
}
