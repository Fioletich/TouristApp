using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TouristApp.Application;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.MappingProfiles;
using TouristApp.Persistance;
using TouristApp.WebApi.Identity;
using TouristApp.WebApi.Middleware;

namespace TouristApp.WebApi;

public class Startup(IConfiguration configuration) {
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services) {
        services.AddApplication();
        services.AddPersistance(configuration);
        services.AddAutoMapper(typeof(TouristAppMappingProfile));
        services.AddControllers();
        services.AddLogging();
        
        services.AddScoped<ITouristApplicationDbContext>(provider => 
            provider.GetRequiredService<TouristApplicationDbContext>());
        services.AddSingleton<TokenGenerator>();
            
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

        services.AddSwaggerGen(options =>
        { 
            options.SwaggerDoc("v1", new OpenApiInfo {Title = "Test", Version = "v1"});
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter JWT token",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                }, 
                new string[] {}
            }});
        });

        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]!)),
                    ValidIssuer = Configuration["JwtSettings:Issuer"],
                    ValidAudience = Configuration["JwtSettings:Audience"],
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true
                };
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    { 
        
        app.UseDeveloperExceptionPage();
        app.UseCustomExceptionHandler();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
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