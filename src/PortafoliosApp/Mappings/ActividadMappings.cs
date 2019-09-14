using AutoMapper;
using PortafoliosApp.Commands;
using PortafoliosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortafoliosApp.Mappings
{
    public class ActividadMappings: Profile
    {
        public ActividadMappings()
        {
            CreateMap<ActualizarActividad, Actividad>();
            CreateMap<CrearActividad, Actividad>();
        }
    }
}
