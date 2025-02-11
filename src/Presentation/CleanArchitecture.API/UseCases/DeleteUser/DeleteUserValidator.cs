using CleanArchitecture.Application.Shared.UserCQRS;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.DeleteUser;

public sealed class DeleteUserValidator : AbstractValidator<UserRequest.DeleteUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(user => user.Id).NotEmpty();
    }
}
