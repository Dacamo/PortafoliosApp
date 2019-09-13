using Newtonsoft.Json;
using PortafoliosApp.Domain.Models;
using PortafoliosApp.Test.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

        [Fact]
        public async Task Post_Portafolio_RetornaPortafolioCreado()
        {
            // Preparar
            var portafolio = new Portafolio
            {
               Id = 1,
               Descripcion = "descripcion",
               FechaInicio = DateTime.Parse("jan 1, 2009")

            };

            // Ejecutar
            var response = await _client.PostAsJsonAsync("/api/portafolios", portafolio);
            var content = await response.Content.ReadAsStringAsync();
            var nuevoPortafolio = JsonConvert.DeserializeObject<Portafolio>(content);

            // Validar
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(1, nuevoPortafolio.Id);
            Assert.Equal("descripcion", nuevoPortafolio.Descripcion);
            Assert.Equal(DateTime.Parse("jan 1, 2009"), nuevoPortafolio.FechaInicio);
           
        }

    }
}
