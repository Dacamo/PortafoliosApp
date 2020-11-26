using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortafoliosApp.Domain.Models
{
    public class Actividad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Tutor { get; set; }
        [Required]
        public int Puntaje { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int PortafolioId { get; set; }

        [ForeignKey("PortafolioId")]
        public virtual Portafolio Portafolio { get; set; }
    }
}
