using Microsoft.Extensions.DependencyInjection;

namespace Common.Utilities
{
    public static class Extensions
    {
        public static IServiceCollection AddUtilities(this IServiceCollection services)
        {
            services.AddSingleton<IHashingService, HashingService>();
            return services;
        }
    }
}