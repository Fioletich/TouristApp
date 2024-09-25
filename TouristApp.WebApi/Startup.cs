﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Persistance;

namespace TouristApp.WebApi;

public class Startup {
    public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddLogging();
            var connectionString = Configuration["DbConnection"];
            
            services.AddDbContext<TouristApplicationDbContext>(options => 
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<ITouristApplicationDbContext>(provider =>
                provider.GetRequiredService<TouristApplicationDbContext>());

            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(typeof(NotFoundException).Assembly);
            });
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test v1"));

            app.UseEndpoints(options =>
            {
                options.MapControllers();
            });
        }
}