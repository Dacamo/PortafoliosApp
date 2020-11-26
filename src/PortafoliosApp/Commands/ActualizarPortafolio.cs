using System;
using System.ComponentModel.DataAnnotations;

namespace PortafoliosApp.Commands
{
    public class ActualizarPortafolio
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Objetivo { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
    }
}
