using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Infrastructure;
using MediatR;

namespace CleanArchitecture.API.UseCases.UpdateUser
{
    public class UpdateUserEndpoint : IEndpointDefinition
    {
        public void RegisterEndpoints(IEndpointRouteBuilder app)
        {
            app.MapPut("/api/users/{id}", Update)
                 .WithSummary("Update an existing user in database")
                 .WithDescription("Update an existing user in the database based on the provided id. The fields 'email' and 'name' can be changed.")
                 .WithTags("Users");
        }

        public static async Task<IResult> Update(Guid id, UserRequest.UpdateUserRequest request, IMediator mediator, CancellationToken cancellationToken)
        {
            try
            {
                if (id != request.Id) return Results.BadRequest();

                var response = await mediator.Send(request, cancellationToken);
                return Results.Ok(response);
            }
            catch (FluentValidation.ValidationException e)
            {
                return Results.Problem(e.Message);
            }
        }
    }
}
