using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Infrastructure;
using MediatR;

namespace CleanArchitecture.API.UseCases.GetByEmailUser
{
    public class GetByEmailUserEndpoint : IEndpointDefinition
    {
        public void RegisterEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/users/{email}", GetByEmail)
                .WithSummary("Get an user by its email")
                .WithDescription("Retrieves user information based on the provided email address.")
                .WithTags("Users");
        }

        public static async Task<IResult> GetByEmail(string? email, IMediator mediator, CancellationToken cancellationToken)
        {
            try
            {
                var response = await mediator.Send(new UserRequest.GetByEmailUser(email), cancellationToken);
                return Results.Ok(response);
            }
            catch (FluentValidation.ValidationException e)
            {
                return Results.Problem(e.Message);
            }
        }
    }
}
