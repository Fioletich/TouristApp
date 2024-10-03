using Serilog;
using Serilog.Events;

namespace TouristApp.WebApi;

public class Program {
    public static void Main(string[] args) {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .WriteTo.File("TouristApplicationLog-.txt.log", rollingInterval:
                RollingInterval.Day)
            .CreateLogger();
        
        var host = CreateHostBuilder(args)
            .UseSerilog()
            .Build();
        
        host.Run();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}   