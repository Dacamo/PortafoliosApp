using System.Collections.Generic;
using System.Threading.Tasks;
using PortafoliosApp.Domain.Models;

namespace PortafoliosApp.Domain.Behaviors
{
    public interface IActividadBehavior
    {
        Task CreateAsync(Actividad actividad);
        Task<List<Actividad>> GetAllAsync();
        Task<Actividad> GetByIdAsync(int id);
        Task UpdateAsync(Actividad actividad);
    }
}