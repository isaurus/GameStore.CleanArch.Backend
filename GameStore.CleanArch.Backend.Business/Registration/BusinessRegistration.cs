using GameStore.CleanArch.Backend.Business.Services;
using GameStore.CleanArch.Backend.Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.CleanArch.Backend.Business.Registration
{
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();

            return services;
        }
    }
}
