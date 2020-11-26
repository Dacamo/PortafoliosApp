using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortafoliosApp.Domain.Models
{
    public class ActividadUsuarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public bool Asistencia { get; set; }
        [Required]
        public int ActividadId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("ActividadId")]
        public virtual Actividad Actividad { get; set; }
    }
}
