using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace GameStore.CleanArch.Backend.WebApi.Registration
{
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            var enabled = Application.Registration.ConfigurationManager.SwaggerEnabled;

            if (enabled)
            {
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                services.AddEndpointsApiExplorer();

                // FALTA AÑADIR 'AddSecurityDefinitions' y 'AddSecurityRequirement'
                services.AddSwaggerGen(c =>
                {
                    c.ExampleFilters();
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
            }

            return services;
        }
    }
}