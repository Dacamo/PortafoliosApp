using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortafoliosApp.Domain.Models
{
    public class Portafolio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set;}
        [Required]
        public string Objetivo { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
    }
}
