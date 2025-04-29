using GameStore.CleanArch.Backend.Application.Registration;
using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Infrastructure.Context;
using GameStore.CleanArch.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.CleanArch.Backend.Infrastructure.Registration
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationManager.LocalDB));
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConfigurationManager.Docker));

            services.AddScoped<IGameRepository, GameRepository>();

            return services;
        }
    }
}
