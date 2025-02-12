﻿using CleanArchitecture.Application.Shared.Behavior;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace CleanArchitecture.Application.Services;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(config => 
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
