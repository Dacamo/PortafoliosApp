using FamiliesApp.Domain.Infrastructure.Repositories;
using PortafoliosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortafoliosApp.Domain.Behaviors
{
    public class ActividadUsuarioBehavior : IActividadUsuarioBehavior
    {
        private readonly IDataStorage<ActividadUsuarios> _actividadUsuarioRepository;

        public ActividadUsuarioBehavior(IDataStorage<ActividadUsuarios> actividadUsuarioRepository)
        {
            _actividadUsuarioRepository = actividadUsuarioRepository;
        }

        public async Task CreateAsync(ActividadUsuarios actividadUsuario)
        {
            if (actividadUsuario == null) throw new ArgumentNullException(nameof(actividadUsuario));

            var actividadUsuarioExistente = await _actividadUsuarioRepository.FirstOrDefaultAsync(au => au.ActividadId == actividadUsuario.ActividadId && au.UsuarioId == actividadUsuario.UsuarioId);

            if (actividadUsuarioExistente != null) throw new Exception("Usuario ya registrado en la actividad");
                          
            actividadUsuario.FechaRegistro = DateTime.Now;

            await _actividadUsuarioRepository.InsertAsync(actividadUsuario);
        }

        public async Task DeleteAsync(ActividadUsuarios actividadUsuario)
        {
            await _actividadUsuarioRepository.DeleteAsync(actividadUsuario);
        }

        public async Task<List<ActividadUsuarios>> GetAllAsync()
        {
            return await _actividadUsuarioRepository.FindAsync(includeProperties: "Usuario");
        }

        public async Task<List<ActividadUsuarios>> GetByActividadIdAsync(int id)
        {
            return await _actividadUsuarioRepository.FindAsync(actividadId => actividadId.ActividadId == id, includeProperties: "Usuario");
        }

        public async Task<ActividadUsuarios> GetByIdAsync(int id)
        {
            return await _actividadUsuarioRepository.FirstOrDefaultAsync(actividadUsuario => actividadUsuario.Id == id);
        }

        public async Task UpdateAsync(ActividadUsuarios actividadUsuario)
        {
            await _actividadUsuarioRepository.UpdateAsync(actividadUsuario);
        }

    }
}
