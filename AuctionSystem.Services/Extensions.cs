using AuctionSystem.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuctionSystem.Services
{
    public static class Extensions
    {
        public static IServiceCollection AddRequiredServices(this IServiceCollection services)
        {
            services.AddScoped<IAuctionService, AuctionService>();

            services.AddSingleton<LoginService>();
            services.AddSingleton<ILoginService>(x => x.GetRequiredService<LoginService>());
            services.AddSingleton<IHostedService>(x => x.GetRequiredService<LoginService>());

            return services;
        }
    }
}