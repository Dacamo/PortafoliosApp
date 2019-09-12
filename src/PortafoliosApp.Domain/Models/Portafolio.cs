using System;
using System.Collections.Generic;
using System.Text;

namespace PortafoliosApp.Domain.Models
{
    public class Portafolio
    {
        public int Id { get; set; }
        public string Descripcion { get; set;}
        public DateTime FechaInicio { get; set; }
    }
}
