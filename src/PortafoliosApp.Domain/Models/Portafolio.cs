using System;
using System.ComponentModel.DataAnnotations;

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
