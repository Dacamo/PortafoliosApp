using System.ComponentModel.DataAnnotations;

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
