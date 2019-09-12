﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class PortafoliosController : ControllerBase
    {
        private readonly IPortafolioBehavior _portafolioBehavior;
        private readonly IMapper _mapper;
        public PortafoliosController(IPortafolioBehavior portafolioBehavior)
        {
            _portafolioBehavior = portafolioBehavior;

        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Portafolio>> CreateAsync(Portafolio portafolio)
        {
            await _portafolioBehavior.CreateAsync(portafolio);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = portafolio.Id }, portafolio);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<Portafolio>> GetAllAsync()
        {
            return await _portafolioBehavior.GetAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Portafolio>> GetByIdAsync(int id)
        {
            var portafolioExistente = await _portafolioBehavior.GetByIdAsync(id);
            if (portafolioExistente == null)
            {
                return NotFound();
            }
            return portafolioExistente;

        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateAsync(int id, Portafolio portafolio)
        {
            var portafolioExistente = await _portafolioBehavior.GetByIdAsync(id);
            if (portafolioExistente == null)
            {
                return NotFound();
            }
            _mapper.Map(portafolio, portafolioExistente);
            await _portafolioBehavior.UpdateAsync(portafolioExistente);

            return NoContent();
        }
    }
}
