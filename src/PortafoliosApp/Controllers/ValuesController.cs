using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PortafoliosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<string>>> GetAllAsync()
        {
            return new string[] { "value1", "value2" };
        }

        
    }
}
