using Microsoft.AspNetCore.Mvc;
using PortafoliosApp.Domain.Behaviors;
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
        public PortafoliosController(IPortafolioBehavior portafolioBehavior)
        {
            _portafolioBehavior = portafolioBehavior;

        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetAllAsync()
        {

        }
    }
}
