using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Infrastructure;
using MediatR;

namespace CleanArchitecture.API.UseCases.DeleteUser
{
    public class DeleteUserEndpoint : IEndpointDefinition
    {
        public void RegisterEndpoints(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/users/{id}", Delete)
               .WithSummary("Remove an existing user from database")
               .WithDescription("Gets an user from the provided id and deletes it from the database.")
                .WithTags("Users");
        }
        public static async Task<IResult> Delete(Guid? id, IMediator mediator, CancellationToken cancellationToken)
        {
            try
            {
                if (id == null) return Results.BadRequest();

                var deleteUser = new UserRequest.DeleteUserRequest(id.Value);

                var response = await mediator.Send(deleteUser, cancellationToken);
                return Results.Ok(response);
            }
            catch (FluentValidation.ValidationException e)
            {
                return Results.Problem(e.Message);
            }
        }
    }
}
