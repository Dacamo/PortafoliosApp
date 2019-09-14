using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortafoliosApp.Domain.Models
{
    public class Actividad
    {
        public int Id { get; set; }
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
