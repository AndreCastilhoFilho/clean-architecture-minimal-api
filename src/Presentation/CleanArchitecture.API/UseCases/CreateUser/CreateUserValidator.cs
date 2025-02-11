using CleanArchitecture.Application.Shared.UserCQRS;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<UserRequest.CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Email).NotEmpty().MaximumLength(64).EmailAddress();
        RuleFor(user => user.Name).NotEmpty().MinimumLength(3).MaximumLength(75);
    }
}
