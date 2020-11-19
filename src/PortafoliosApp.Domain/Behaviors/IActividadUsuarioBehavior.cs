using PortafoliosApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortafoliosApp.Domain.Behaviors
{
    public interface IActividadUsuarioBehavior
    {
        Task CreateAsync(ActividadUsuarios actividadBehavior);
        Task<List<ActividadUsuarios>> GetAllAsync();
        Task<ActividadUsuarios> GetByIdAsync(int id);
        Task UpdateAsync(ActividadUsuarios actividadBehavior);
        Task DeleteAsync(ActividadUsuarios actividadBehavior);
    }
}
