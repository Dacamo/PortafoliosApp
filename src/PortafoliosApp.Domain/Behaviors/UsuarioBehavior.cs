using FamiliesApp.Domain.Infrastructure.Repositories;
using PortafoliosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortafoliosApp.Domain.Behaviors
{
    public class UsuarioBehavior : IUsuarioBehavior
    {
        private readonly IDataStorage<Usuario> _usuarioRepository;

        public UsuarioBehavior(IDataStorage<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CreateAsync(Usuario usuario)
        {
            if(usuario == null) throw new ArgumentNullException(nameof(usuario));

            //TODO agregar validacion para usuario no existente.

            await _usuarioRepository.InsertAsync(usuario);
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            if(usuario == null) throw new ArgumentNullException(nameof(usuario));

            await _usuarioRepository.DeleteAsync(usuario);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.FindAllAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            if(id.Equals("")) throw new ArgumentNullException(nameof(id));

            return await _usuarioRepository.FirstOrDefaultAsync(usuario => usuario.Id == id);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
