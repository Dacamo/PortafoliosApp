using AutoMapper;
using PortafoliosApp.Commands;
using PortafoliosApp.Domain.Models;

namespace PortafoliosApp.Mappings
{
    public class PortafolioMappings : Profile
    {
        public PortafolioMappings()
        {
            CreateMap<ActualizarPortafolio, Portafolio>();
            CreateMap<CrearPortafolio, Portafolio>();
            
        }
    }
}
