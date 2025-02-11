using CleanArchitecture.Application.Services;
using CleanArchitecture.Persistence;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.API.Extensions;

public static class BuilderExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureApplicationApp();
        builder.Services.ConfigurePersistenceApp(builder.Configuration);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Users API",
                Description = "Minimal API implemented with Clean Architecture",
                Version = "v1",
            });
        });

        return builder;
    }
}
