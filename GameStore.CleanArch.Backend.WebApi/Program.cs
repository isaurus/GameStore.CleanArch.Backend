using System.Reflection;
using GameStore.CleanArch.Backend.Application.Registration;
using GameStore.CleanArch.Backend.Business.Registration;
using GameStore.CleanArch.Backend.Business.Services;
using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Domain.Contracts.Services;
using GameStore.CleanArch.Backend.Infrastructure.Context;
using GameStore.CleanArch.Backend.Infrastructure.Registration;
using GameStore.CleanArch.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GameStore.CleanArch.Backend.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Registro de servicios (directorios 'Registration')
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddBusinessServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Registrar servicios de Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Game Store API",
                    Description = "RESTful API con Clean Architecture para gestionar una tienda de videojuegos",
                    Contact = new OpenApiContact
                    {
                        Name = "Isaac Martín",
                        Email = "isaacmartin.dev@gmail.com",
                        Url = new Uri("https://github.com/isaurus"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    },
                });

                // Configuración para XML Comments
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);

                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
                else
                {
                    // Opcional: Loggear advertencia si el archivo no existe
                    Console.WriteLine($"XML documentation file not found: {xmlPath}");
                }
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
