using CleanArchitecture.Application.Shared.UserCQRS;
using FluentValidation;

namespace CleanArchitecture.Application;

public class GetByEmailUserValidator : AbstractValidator<UserRequest.GetByEmailUser>
{
    public GetByEmailUserValidator()
    {
        RuleFor(user => user.Email).NotEmpty().MaximumLength(64).EmailAddress();
    }
}
