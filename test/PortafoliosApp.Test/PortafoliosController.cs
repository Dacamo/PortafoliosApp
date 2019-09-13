using Newtonsoft.Json;
using PortafoliosApp.Commands;
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
        public async Task Get_Portafolios_Returns_EmptyList()
        {
            // Ejecutar
            var response = await _client.GetAsync("/api/portafolios");
            var content = await response.Content.ReadAsStringAsync();

            // Validar
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("[]", content);
        }

        [Fact]
        public async Task Post_Portafolio_Returns_PortafolioCreado()
        {
            // Preparar
            var portafolio = new Portafolio
            {
               Id = 1,
               Descripcion = "descripcion",
               FechaInicio = DateTime.Parse("jan 1, 2009"),
               Objetivo = "objetivo"
            };

            // Ejecutar
            var response = await _client.PostAsJsonAsync("/api/portafolios", portafolio);
            var content = await response.Content.ReadAsStringAsync();
            var nuevoPortafolio = JsonConvert.DeserializeObject<Portafolio>(content);

            // Validar
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(1, nuevoPortafolio.Id);
            Assert.Equal("descripcion", nuevoPortafolio.Descripcion);
            Assert.Equal(DateTime.Parse("jan 1, 2009"),
                nuevoPortafolio.FechaInicio);
            Assert.Equal("objetivo", nuevoPortafolio.Objetivo);
           
        }

        [Fact]
        public async Task Post_PortafolioSinDescripcion_Returns_Error()
        {
            // Preparar
            var crearPortafolioCommand = new CrearPortafolio
            {
               
                FechaInicio = DateTime.Parse("jan 1, 2009"),
                Objetivo = "objetivo"

            };

            // Ejecutar
            var response = await _client.PostAsJsonAsync("/api/portafolios", crearPortafolioCommand);

            // Validar
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Post_PortafolioSinObjetivo_Returns_Error()
        {
            // Preparar
            var crearPortafolioCommand = new CrearPortafolio
            {
                Descripcion = "descripcion",
                FechaInicio = DateTime.Parse("jan 1, 2009"),
                
            };

            // Ejecutar
            var response = await _client.PostAsJsonAsync("/api/portafolios", crearPortafolioCommand);

            // Validar
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_PortafolioById_Returns_Portafolio()
        {
            //preparar
            var crearPortafolioCommand = new CrearPortafolio
            {
                Descripcion= "descripcion",
                Objetivo = "objetivo",
                FechaInicio = DateTime.Parse("jan 1, 2009")
            };

            await _client.PostAsJsonAsync("/api/portafolios", crearPortafolioCommand);
            var response = await _client.GetAsync("/api/portafolios/1");
            var content = await response.Content.ReadAsStringAsync();
            var portafolio = JsonConvert.DeserializeObject<Portafolio>(content);


            // Validar
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


             // Portafolio 1
            Assert.Equal(1, portafolio.Id);
            Assert.Equal("descripcion", portafolio.Descripcion);
            Assert.Equal("objetivo", portafolio.Objetivo);
            Assert.Equal(DateTime.Parse("jan 1, 2009"), portafolio.FechaInicio);
        }

        [Fact]
        public async Task Get_PortafolioById_Retorna_NotFound()
        {
            //preparar
            var response = await _client.GetAsync("/api/portafolios/1");
           
            
            // Validar
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }

        [Fact]
        public async Task Get_Portafolios_Returns_PortafoliosList() {
            
            //preparar
            var crearPortafolioCommand1 = new CrearPortafolio
            {
                Descripcion = "descripcion1",
                Objetivo = "objetivo1",
                FechaInicio = DateTime.Parse("jan 1, 2009")
            };

            var crearPortafolioCommand2 = new CrearPortafolio
            {
                Descripcion = "descripcion2",
                Objetivo = "objetivo2",
                FechaInicio = DateTime.Parse("jan 2, 2009")
            };

            await _client.PostAsJsonAsync("/api/portafolios", crearPortafolioCommand1);
            await _client.PostAsJsonAsync("/api/portafolios", crearPortafolioCommand2);

            //ejecutar
            var response = await _client.GetAsync("/api/portafolios");
            var content = await response.Content.ReadAsStringAsync();
            var portafolios = JsonConvert.DeserializeObject<List<Portafolio>>(content);

            // Validar
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(2, portafolios.Count);

            // Portafolio 1
            Assert.Equal(1, portafolios[0].Id);
            Assert.Equal("objetivo1", portafolios[0].Objetivo);
            Assert.Equal("descripcion1", portafolios[0].Descripcion);
            Assert.Equal(DateTime.Parse("jan 1, 2009"), portafolios[0].FechaInicio);


            // Portafolio 2
            Assert.Equal(2, portafolios[1].Id);
            Assert.Equal("objetivo2", portafolios[1].Objetivo);
            Assert.Equal("descripcion2", portafolios[1].Descripcion);
            Assert.Equal(DateTime.Parse("jan 2, 2009"), portafolios[1].FechaInicio);
        }


        [Fact]
        public async Task Put_Portafolio_Return_Success()
        {
            //preparar

            //portafolio
            var crearPortafolioCommand = new CrearPortafolio
            {
                Descripcion = "descripcion",
                Objetivo = "objetivo",
                FechaInicio = DateTime.Parse("jan 1, 2009")
            };

            await _client.PostAsJsonAsync("/api/portafolios", crearPortafolioCommand);

            //nueva informacion portafolio
            var actualizarPortafolioCommand = new ActualizarPortafolio
            {
                Descripcion = "NuevaDescripcion",
                Objetivo = "NuevoObjetivo",
                FechaInicio = DateTime.Parse("jan 1, 2018")
            };

            //ejecutar
            var response = await _client.PutAsJsonAsync("/api/portafolios/1", actualizarPortafolioCommand);


            //validar
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            var response2 = await _client.GetAsync("/api/portafolios/1");
            var content = await response2.Content.ReadAsStringAsync();
            var portafolio = JsonConvert.DeserializeObject<Portafolio>(content);

           
            Assert.Equal(1, portafolio.Id);
            Assert.Equal(actualizarPortafolioCommand.Descripcion, portafolio.Descripcion);
            Assert.Equal(actualizarPortafolioCommand.Objetivo, portafolio.Objetivo);
            Assert.Equal(actualizarPortafolioCommand.FechaInicio, portafolio.FechaInicio);
        }
    }
}
