using Microsoft.AspNetCore.Routing;

namespace CleanArchitecture.Infrastructure
{
    public interface IEndpointDefinition
    {
        void RegisterEndpoints(IEndpointRouteBuilder app);

    }
}
