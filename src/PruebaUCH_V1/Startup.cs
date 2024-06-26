﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PruebaUCH_V1.Data;
using PruebaUCH_V1.Interfaces;
using PruebaUCH_V1.Repositories;

namespace PruebaUCH_V1;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Agregar el contexto de la base de datos y configurar la cadena de conexión
        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

        // Registrar el repositorio como un servicio
        services.AddScoped<IPropertyRepository, PropertyRepository>();

        // Configurar Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaUCH_V1 API", Version = "v1" });
        });

        // Configurar AutoMapper
        services.AddAutoMapper(typeof(Startup));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaUCH_V1 API V1");
            c.RoutePrefix = string.Empty;  // Set Swagger UI at the app's root
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}