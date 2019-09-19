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
    public class ActividadesController : ControllerBase
    {
        private readonly IActividadBehavior _actividadBehavior;
        private readonly IMapper _mapper;

        public ActividadesController(IActividadBehavior actividadBehavior, IMapper mapper)
        {
            _actividadBehavior = actividadBehavior;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Actividad>> CreateAsync(CrearActividad crearActividad)
        {
            var actividad = _mapper.Map<Actividad>(crearActividad);

            await _actividadBehavior.CreateAsync(actividad);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = actividad.Id }, actividad);
        }
        [HttpGet]
        public async Task<List<Actividad>> GetAllAsync()
        {
            return await _actividadBehavior.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actividad>> GetByIdAsync(int id)
        {
            var actividadExistente = await _actividadBehavior.GetByIdAsync(id);

            if(actividadExistente == null)
                return NotFound();

            return actividadExistente;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ActualizarActividad actualizarActividad)
        {
            var actividad = await _actividadBehavior.GetByIdAsync(id);

            if(actividad == null)
                return NotFound();

            _mapper.Map(actualizarActividad, actividad);
            await _actividadBehavior.UpdateAsync(actividad);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var actividadExistente = await _actividadBehavior.GetByIdAsync(id);
            if (actividadExistente == null)
            {
                return NotFound();
            }

            await _actividadBehavior.DeleteAsync(actividadExistente);
            return NoContent();
        }


        [HttpGet("portafolioId/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<List<Actividad>> GetAllActividades(int id)
        {
            return await _actividadBehavior.GetAllActividadesByPortafolioId(id);
        }
    }
}
