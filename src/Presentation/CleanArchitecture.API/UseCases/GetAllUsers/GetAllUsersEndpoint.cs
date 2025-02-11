using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Infrastructure;
using MediatR;

namespace CleanArchitecture.API.UseCases.GetAllUsers
{
    public class GetAllUsersEndpoint : IEndpointDefinition
    {
        public void RegisterEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/users", GetAll)
               .WithSummary("Lists all users in database")
               .WithDescription("Retrieves a list of all users stored in the database.")
               .WithTags("Users");
        }

        public static async Task<IResult> GetAll(IMediator mediator, CancellationToken cancellationToken)
        {

            var response = await mediator.Send(new UserRequest.GetAllUsersRequest(), cancellationToken);
            return Results.Ok(response);

        }
    }
}
