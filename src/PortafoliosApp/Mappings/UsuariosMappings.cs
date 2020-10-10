using AutoMapper;
using PortafoliosApp.Commands;
using PortafoliosApp.Domain.Models;

namespace PortafoliosApp.Mappings
{
    public class UsuariosMappings : Profile
    {
        public UsuariosMappings()
        {
            CreateMap<ActualizarUsuario, Usuario>();
        }
    }
}
