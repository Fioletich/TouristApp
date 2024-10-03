﻿using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TouristApp.Application.Common.Beheviors;

namespace TouristApp.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), 
            typeof(LoggingBehavior<,>));
        

        return services;
    }
}