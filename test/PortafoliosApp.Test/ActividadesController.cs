using Newtonsoft.Json;
using PortafoliosApp.Commands;
using PortafoliosApp.Domain.Models;
using PortafoliosApp.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PortafoliosApp.Test
{
    public class ActividadesController: WebTest
    {
        [Fact]
        public async Task Get_Actividades_Returns_EmptyList()
        {
            // Ejecutar
            var response = await _client.GetAsync("/api/actividades");
            var content = await response.Content.ReadAsStringAsync();

            // Validar
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("[]", content);
        }

        [Fact]
        public async Task Post_Actividad_Returns_ActividadCreado()
        {
            // Preparar
            var actividad = new Actividad
            {
                Id = 1,
                Descripcion = "descripcion",
                Fecha = DateTime.Parse("jan 1, 2009"),
                Tutor = "tutor",
                Puntaje = 15
                
            };

            // Ejecutar
            var response = await _client.PostAsJsonAsync("/api/actividades", actividad);
            var content = await response.Content.ReadAsStringAsync();
            var nuevaActividad = JsonConvert.DeserializeObject<Actividad>(content);

            // Validar
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(1, nuevaActividad.Id);
            Assert.Equal("descripcion", nuevaActividad.Descripcion);
            Assert.Equal(DateTime.Parse("jan 1, 2009"),
                nuevaActividad.Fecha);
            Assert.Equal("tutor", nuevaActividad.Tutor);
            Assert.Equal(15, nuevaActividad.Puntaje);

        }

        [Fact]
        public async Task Post_ActividadSinDescripcion_Returns_Error()
        {
            // Preparar
            var crearActividadCommand = new CrearActividad
            {
                Tutor = "tutor",
                Puntaje = 15,
                Fecha = DateTime.Parse("jan 1, 2009"),

            };

            // Ejecutar
            var response = await _client.PostAsJsonAsync("/api/actividades", crearActividadCommand);

            // Validar
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Post_ActividadSinTutor_Returns_Error()
        {
            // Preparar
            var crearActividadCommand = new CrearActividad
            {
                Descripcion = "descripcion",
                Puntaje = 15,
                Fecha = DateTime.Parse("jan 1, 2009"),

            };

            // Ejecutar
            var response = await _client.PostAsJsonAsync("/api/actividades", crearActividadCommand);

            // Validar
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        
        [Fact]
        public async Task Get_ActividadById_Returns_Actividad()
        {
            //preparar
            var crearActividadCommand = new CrearActividad
            {
                Descripcion = "descripcion",
                Puntaje = 15,
                Fecha = DateTime.Parse("jan 1, 2009"),
                Tutor = "tutor"

            };

            await _client.PostAsJsonAsync("/api/actividades", crearActividadCommand);
            var response = await _client.GetAsync("/api/actividades/1");
            var content = await response.Content.ReadAsStringAsync();
            var actividad = JsonConvert.DeserializeObject<Actividad>(content);


            // Validar
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            // actividad 1
            Assert.Equal(1, actividad.Id);
            Assert.Equal("descripcion", actividad.Descripcion);
            Assert.Equal("tutor", actividad.Tutor);
            Assert.Equal(DateTime.Parse("jan 1, 2009"), actividad.Fecha);
        }

        
        [Fact]
        public async Task Get_ActividadById_Retorns_NotFound()
        {
            //preparar
            var response = await _client.GetAsync("/api/actividades/1");


            // Validar
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }

        
        [Fact]
        public async Task Get_Actividades_Returns_ActividadesList()
        {

            //preparar
           var crearActividadCommand1 = new CrearActividad
            {
                Descripcion = "descripcion1",
                Puntaje = 1,
                Fecha = DateTime.Parse("jan 1, 2009"),
                Tutor = "tutor1"

            };

           var crearActividadCommand2 = new CrearActividad
            {
                Descripcion = "descripcion2",
                Puntaje = 2,
                Fecha = DateTime.Parse("jan 2, 2009"),
                Tutor = "tutor2"
            };

            await _client.PostAsJsonAsync("/api/actividades", crearActividadCommand1);
            await _client.PostAsJsonAsync("/api/actividades", crearActividadCommand2);

            //ejecutar
            var response = await _client.GetAsync("/api/actividades");
            var content = await response.Content.ReadAsStringAsync();
            var actividades = JsonConvert.DeserializeObject<List<Actividad>>(content);

            // Validar
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(2, actividades.Count);

            // actividad 1
            Assert.Equal(1, actividades[0].Id);
            Assert.Equal("tutor1", actividades[0].Tutor);
            Assert.Equal("descripcion1", actividades[0].Descripcion);
            Assert.Equal(DateTime.Parse("jan 1, 2009"), actividades[0].Fecha);


            // actividad 2
            Assert.Equal(2, actividades[1].Id);
            Assert.Equal("tutor2", actividades[1].Tutor);
            Assert.Equal("descripcion2", actividades[1].Descripcion);
            Assert.Equal(DateTime.Parse("jan 2, 2009"), actividades[1].Fecha);
        }

        
        [Fact]
        public async Task Put_Actividad_Returns_Success()
        {
            //preparar

            //actividad
            var crearActividadCommand = new CrearActividad
            {
                Descripcion = "descripcion",
                Puntaje = 1,
                Fecha = DateTime.Parse("jan 1, 2009"),
                Tutor = "tutor"

            };

            await _client.PostAsJsonAsync("/api/actividades", crearActividadCommand);

            //nueva informacion actividad
            var actualizarActividadCommand = new ActualizarActividad
            {
                Descripcion = "NuevaDescripcion",
                Puntaje = 80,
                Tutor = "NuevoTutor",
                Fecha = DateTime.Parse("jan 1, 2018")
            };

            //ejecutar
            var response = await _client.PutAsJsonAsync("/api/actividades/1", actualizarActividadCommand);


            //validar
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            var response2 = await _client.GetAsync("/api/actividades/1");
            var content = await response2.Content.ReadAsStringAsync();
            var portafolio = JsonConvert.DeserializeObject<Actividad>(content);


            Assert.Equal(1, portafolio.Id);
            Assert.Equal(actualizarActividadCommand.Descripcion, portafolio.Descripcion);
            Assert.Equal(actualizarActividadCommand.Tutor, portafolio.Tutor);
            Assert.Equal(actualizarActividadCommand.Fecha, portafolio.Fecha);
        }

        
        [Fact]
        public async Task Put_Actividad_Returns_NotFound()
        {
            //preparar


            //nueva informacion de actividad
            var actualizarActividadCommand = new ActualizarActividad
            {
                Descripcion = "NuevaDescripcion",
                Tutor= "TutorNuevo",
                Fecha = DateTime.Parse("jan 1, 2018"),
                Puntaje = 10

            };

            //ejecutar
            var response = await _client.PutAsJsonAsync("/api/actividades/2", actualizarActividadCommand);

            //validar
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
