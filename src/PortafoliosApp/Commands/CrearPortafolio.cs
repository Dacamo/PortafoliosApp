using System;
using System.ComponentModel.DataAnnotations;

namespace PortafoliosApp.Commands
{
    public class CrearPortafolio
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Objetivo { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
    }
}
