using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TouristApp.Application.Interfaces;
using TouristApp.Persistance;

namespace TestApp;
public static class Program {
    public static async Task Main(string[] args) {
        var hostBuilder = CreateHostBuilder(args);

        await hostBuilder.RunConsoleAsync();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddDbContext<TouristApplicationDbContext>(options =>
                    options.UseNpgsql("Host=localhost;Port=1111;Database=postgres;Username=postgres;Password=123789pr"));

                services
                    .AddScoped<ITouristApplicationDbContext>(provider =>
                        provider.GetService<TouristApplicationDbContext>());

                services.AddLogging();

                services.AddMediatR(c =>
                    c.RegisterServicesFromAssemblyContaining(typeof(ITouristApplicationDbContext)));
                services.AddSingleton<IHostedService, ConsoleApp>();
            });
}