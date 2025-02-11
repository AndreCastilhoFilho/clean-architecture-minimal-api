using CleanArchitecture.Infrastructure;
using System.Reflection;

public static class EndpointExtensions
{
    public static void RegisterEndpointsFromAssembly(this IEndpointRouteBuilder app, Assembly assembly)
    {
        var endpointDefinitions = assembly
            .GetTypes()
            .Where(t => typeof(IEndpointDefinition).IsAssignableFrom(t) && t is { IsAbstract: false, IsInterface: false })
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var endpoint in endpointDefinitions)
        {
            endpoint.RegisterEndpoints(app);
        }
    }
}