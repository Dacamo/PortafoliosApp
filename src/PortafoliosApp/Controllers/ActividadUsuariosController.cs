using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortafoliosApp.Commands;
using PortafoliosApp.Domain.Behaviors;
using PortafoliosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortafoliosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadUsuariosController : ControllerBase
    {
        private readonly IActividadUsuarioBehavior _actividadUsuarioBehavior;
        private readonly IMapper _mapper;

        public ActividadUsuariosController(IActividadUsuarioBehavior actividadUsuarioBehavior, IMapper mapper)
        {
            _actividadUsuarioBehavior = actividadUsuarioBehavior;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult<ActividadUsuarios>> CreateAsync(CrearActividadUsuario crearActividadUsuario)
        {
            var actividadUsuario = _mapper.Map<ActividadUsuarios>(crearActividadUsuario);

            await _actividadUsuarioBehavior.CreateAsync(actividadUsuario);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = actividadUsuario.Id }, actividadUsuario);
        }

        [HttpGet]
        public async Task<List<ActividadUsuarios>> GetAllAsync()
        {
            return await _actividadUsuarioBehavior.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActividadUsuarios>> GetByIdAsync(int id)
        {
            var actividadUsuarioExistente = await _actividadUsuarioBehavior.GetByIdAsync(id);

            if (actividadUsuarioExistente == null)
                return NotFound();

            return actividadUsuarioExistente;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ActualizarActividadUsuario actualizarActividadUsuario)
        {
            var actividadUsuarioExistente = await _actividadUsuarioBehavior.GetByIdAsync(id);

            if (actividadUsuarioExistente == null)
                return NotFound();

            _mapper.Map(actualizarActividadUsuario, actividadUsuarioExistente);

            await _actividadUsuarioBehavior.UpdateAsync(actividadUsuarioExistente);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var actividadUsuarioExistente = await _actividadUsuarioBehavior.GetByIdAsync(id);
            if (actividadUsuarioExistente == null)
            {
                return NotFound();
            }
            await _actividadUsuarioBehavior.DeleteAsync(actividadUsuarioExistente);

            return NoContent();
        }
    }
}
