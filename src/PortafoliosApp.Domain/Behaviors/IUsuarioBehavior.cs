using PortafoliosApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortafoliosApp.Domain.Behaviors
{
    public interface IUsuarioBehavior
    {
        Task CreateAsync(Usuario usuario);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Usuario usuario);
    }
}
