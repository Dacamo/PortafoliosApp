using FamiliesApp.Domain.Infrastructure.Repositories;
using PortafoliosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PortafoliosApp.Domain.Behaviors
{
    public class ActividadBehavior : IActividadBehavior
    {
        private readonly IDataStorage<Actividad> _actividadRepository;

        public ActividadBehavior(IDataStorage<Actividad> actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }

        public async Task CreateAsync(Actividad actividad)
        {
            if (actividad == null)
                throw new ArgumentNullException(nameof(actividad));

            await _actividadRepository.InsertAsync(actividad);
        }

        public async Task<List<Actividad>> GetAllAsync()
        {
            return await _actividadRepository.FindAllAsync();
        }

        public async Task<Actividad> GetByIdAsync(int id)
        {
            return await _actividadRepository.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(Actividad actividad)
        {
            await _actividadRepository.UpdateAsync(actividad);
        }

    }
}
