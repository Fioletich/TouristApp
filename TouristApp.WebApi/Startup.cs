using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TouristApp.Application;
using TouristApp.Application.Interfaces;
using TouristApp.Persistance;
using TouristApp.WebApi.Middleware;

namespace TouristApp.WebApi;

public class Startup(IConfiguration configuration) {
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services) {
        services.AddApplication();
        services.AddPersistance(configuration);
        services.AddControllers();
        services.AddLogging();
        
        services.AddScoped<ITouristApplicationDbContext>(provider => 
            provider.GetRequiredService<TouristApplicationDbContext>());
            
        services.AddControllers();
        
        services.AddCors(setup =>
        {
            setup.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyMethod();
                policy.AllowAnyHeader(); 
                policy.AllowAnyOrigin();
            });
        });

        services.AddSwaggerGen(c =>
        { 
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "Test", Version = "v1"});
        });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    { 
        app.UseDeveloperExceptionPage();
        app.UseCustomExceptionHandler();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "Test v1"));

        app.UseEndpoints(options =>
        {
            options.MapControllers();
        });
    }
}