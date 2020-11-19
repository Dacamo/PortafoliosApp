using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortafoliosApp.Commands
{
    public class CrearActividadUsuario
    {
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int ActividadId { get; set; }
    }
}
