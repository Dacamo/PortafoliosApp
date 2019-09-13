using PortafoliosApp.Test.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PortafoliosApp.Test
{
    public class PortafoliosController : WebTest
    {
        [Fact]
        public async Task Get_Portafolios_ReturnsEmptyList()
        {
            // Ejecutar
            var response = await _client.GetAsync("/api/portafolios");
            var content = await response.Content.ReadAsStringAsync();

            // Validar
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("[]", content);
        }

    }
}
