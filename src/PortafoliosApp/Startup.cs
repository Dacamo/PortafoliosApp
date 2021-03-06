﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FamiliesApp.Domain.Infrastructure.Data;
using FamiliesApp.Domain.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PortafoliosApp.Domain.Behaviors;
using Swashbuckle.AspNetCore.Swagger;

namespace PortafoliosApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                serverOptions => serverOptions.MigrationsAssembly("PortafoliosApp"))
            );
            // Inject DbContext to VortexServices
            services.AddScoped<DbContext>(p => p.GetRequiredService<ApplicationDbContext>());
            services.AddTransient(typeof(IDataStorage<>), typeof(DataStorage<>));
            services.AddScoped<IPortafolioBehavior, PortafolioBehavior>();
            services.AddScoped<IActividadBehavior, ActividadBehavior>();
            services.AddScoped<IUsuarioBehavior, UsuarioBehavior>();
            services.AddScoped<IActividadUsuarioBehavior, ActividadUsuarioBehavior>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "PortafoliosApp", Version = "v1" });
            });

            //services.AddAutoMapper();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var sp = services.BuildServiceProvider();
            // Create a scope to obtain a reference to the database
            // context (ApplicationDbContext).
            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();


                // Ensure the database is created.
                try
                {
                    if (!db.Database.EnsureCreated())
                    {
                        db.Database.Migrate();
                    }
                }
                catch (Exception e)
                {
                    // Do nothing
                }
            }
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();
            

            app.UseMvc();
        }
    }
}
