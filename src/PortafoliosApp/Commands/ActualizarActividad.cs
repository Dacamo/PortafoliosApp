using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortafoliosApp.Commands
{
    public class ActualizarActividad
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Tutor { get; set; }
        [Required]
        public int Puntaje { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
    }
}
