using FamiliesApp.Domain.Infrastructure.Repositories;
using PortafoliosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PortafoliosApp.Domain.Behaviors
{
    public class PortafolioBehavior : IPortafolioBehavior
    {
        private readonly IDataStorage<Portafolio> _portafolioRepository;

        public PortafolioBehavior(IDataStorage<Portafolio> portafolioReporisoty)
        {
            _portafolioRepository = portafolioReporisoty;
        }

        public async Task CreateAsync(Portafolio portafolio)
        {
            if (portafolio == null)
                throw new ArgumentNullException(nameof(portafolio));

            await _portafolioRepository.InsertAsync(portafolio);

        }

        public async Task DeleteAsync(Portafolio portafolio)
        {
            await _portafolioRepository.DeleteAsync(portafolio);
        }

        public async Task<List<Portafolio>> GetAllAsync()
        {
            return await _portafolioRepository.FindAllAsync();
        }

        public async Task<Portafolio> GetByIdAsync(int id)
        {
            return await _portafolioRepository.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task UpdateAsync(Portafolio portafolio)
        {
            await _portafolioRepository.UpdateAsync(portafolio);
        }
    }
}
