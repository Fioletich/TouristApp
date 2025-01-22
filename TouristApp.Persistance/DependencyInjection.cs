using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TouristApp.Persistance;

public static class DependencyInjection {
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<TouristApplicationDbContext>(options => 
        {
            options.UseSqlServer(configuration["DbConnection"], builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        });
        
        return services;
    }
}