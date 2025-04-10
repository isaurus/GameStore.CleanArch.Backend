using GameStore.CleanArch.Backend.Application.Registration;
using GameStore.CleanArch.Backend.Business.Registration;
using GameStore.CleanArch.Backend.Infrastructure.Registration;
using GameStore.CleanArch.Backend.WebApi.Builders;
using GameStore.CleanArch.Backend.WebApi.Registration;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

using FluentValidation.AspNetCore;

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
            builder.Services.AddSwaggerServices();

            builder.Services.AddFluentValidation(conf =>
                conf.RegisterValidatorsFromAssemblyContaining<Application.Features.Game.Validators.GameModelValidator>());

            builder.Services.AddFluentValidationRulesToSwagger();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.AddSwaggerApp();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
