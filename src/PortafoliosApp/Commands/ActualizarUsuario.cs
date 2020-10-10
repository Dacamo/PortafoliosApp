using System;
using System.ComponentModel.DataAnnotations;

namespace PortafoliosApp.Commands
{
    public class ActualizarUsuario
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
