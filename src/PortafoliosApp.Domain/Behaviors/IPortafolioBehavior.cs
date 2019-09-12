using System.Collections.Generic;
using System.Threading.Tasks;
using PortafoliosApp.Domain.Models;

namespace PortafoliosApp.Domain.Behaviors
{
    public interface IPortafolioBehavior
    {
        Task CreateAsync(Portafolio portafolio);
        Task<List<Portafolio>> GetAllAsync();
        Task<Portafolio> GetByIdAsync(int id);
        Task UpdateAsync(Portafolio portafolio);
    }
}