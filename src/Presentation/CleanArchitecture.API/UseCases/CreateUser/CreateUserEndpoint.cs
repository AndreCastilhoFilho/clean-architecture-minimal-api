using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Infrastructure;
using MediatR;


namespace CleanArchitecture.API.UseCases.CreateUser
{
    public class CreateUserEndpoint : IEndpointDefinition
    {
        private const string Route = "/api/users";
        public void RegisterEndpoints(IEndpointRouteBuilder app)
        {
            app.MapPost(Route, Create)
            .WithSummary("Add an user to database")
            .WithDescription("Add an user to the database based on the provided email address and name")
            .WithTags("Users");
        }

        public static async Task<IResult> Create(UserRequest.CreateUserRequest request, IMediator mediator, CancellationToken cancellationToken)
        {
            if (request.Name.StartsWith("A")) throw new InvalidOperationException("We don't accept names that starts with A");

            var response = await mediator.Send(request, cancellationToken);
            return Results.Ok(response);
        }
    }
}
