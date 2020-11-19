using AutoMapper;
using PortafoliosApp.Commands;
using PortafoliosApp.Domain.Models;

namespace PortafoliosApp.Mappings
{
    public class ActividadUsuarioMappings : Profile
    {
        public ActividadUsuarioMappings()
        {
            CreateMap<CrearActividadUsuario, ActividadUsuarios>();
            CreateMap<ActualizarActividadUsuario, ActividadUsuarios>();
        }
    }
}
