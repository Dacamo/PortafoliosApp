using AutoMapper;
using PortafoliosApp.Commands;
using PortafoliosApp.Domain.Models;

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
