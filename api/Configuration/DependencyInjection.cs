using Microsoft.Extensions.DependencyInjection;
using RatingApi.Ratings.Repositories;

namespace RatingApi.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLocalDependencies(this IServiceCollection services)
        {  
            services.AddSingleton<IRatingsRepository, RatingsListRepository>(); //RatingsInMemory-repository? support different inplementations
            return services;
        }
    }
}
