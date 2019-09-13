﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortafoliosApp.Commands
{
    public class ActualizarPortafolio
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Objetivo { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
    }
}
