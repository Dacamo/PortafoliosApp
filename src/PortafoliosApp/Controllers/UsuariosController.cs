using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortafoliosApp.Commands;
using PortafoliosApp.Domain.Behaviors;
using PortafoliosApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortafoliosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioBehavior _usuarioBehavior;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioBehavior usuarioBehavior, IMapper mapper)
        {
            _usuarioBehavior = usuarioBehavior;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateAsync(CrearUsuario crearUsuario)
        {
            var usuario = _mapper.Map<Usuario>(crearUsuario);

            await _usuarioBehavior.CreateAsync(usuario);
            
            return CreatedAtAction(nameof(GetByIdAsync), new { id = usuario.Id }, usuario);
        }

        [HttpGet]
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _usuarioBehavior.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetByIdAsync(int id)
        {
            var usuarioExistente = await _usuarioBehavior.GetByIdAsync(id);

            if (usuarioExistente == null)
                return NotFound();

            return usuarioExistente;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ActualizarUsuario actualizarUsuario)
        {
            var usuarioExistente = await _usuarioBehavior.GetByIdAsync(id);

            if (usuarioExistente == null)
                return NotFound();

            _mapper.Map(actualizarUsuario, usuarioExistente);

            await _usuarioBehavior.UpdateAsync(usuarioExistente);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioExistente = await _usuarioBehavior.GetByIdAsync(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }
            await _usuarioBehavior.DeleteAsync(usuarioExistente);

            return NoContent();
        }
    }
}
