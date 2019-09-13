using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PortafoliosApp.Test.Utils
{
    public class WebTest
    {
        protected readonly HttpClient _client;
        protected readonly CustomWebApplicationFactory<PortafoliosApp.Startup> _factory;

        public WebTest()
        {
            _factory = new CustomWebApplicationFactory<PortafoliosApp.Startup>();
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}
