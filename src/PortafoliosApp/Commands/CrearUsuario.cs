using System;
using System.ComponentModel.DataAnnotations;

namespace PortafoliosApp.Commands
{
    public class CrearUsuario
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
