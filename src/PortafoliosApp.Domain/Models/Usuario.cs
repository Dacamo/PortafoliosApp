using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortafoliosApp.Domain.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
