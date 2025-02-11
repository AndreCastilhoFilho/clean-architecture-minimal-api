using CleanArchitecture.Application.Shared.UserCQRS;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.UpdateUser;

public sealed class UpdateUserValidator : AbstractValidator<UserRequest.UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(user => user.Email).NotEmpty().MaximumLength(64).EmailAddress();
        RuleFor(user => user.Name).NotEmpty().MinimumLength(3).MaximumLength(75);
    }
}
