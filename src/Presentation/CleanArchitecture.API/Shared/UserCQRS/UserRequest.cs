using MediatR;

namespace CleanArchitecture.Application.Shared.UserCQRS;

public static class UserRequest
{
    public sealed record CreateUserRequest (string Email, string Name) : IRequest<UserResponse>;

    public sealed record GetAllUsersRequest : IRequest<List<UserResponse>>;

    public sealed record UpdateUserRequest (Guid Id, string Email, string Name) : IRequest<UserResponse>;

    public sealed record DeleteUserRequest (Guid Id) : IRequest<UserResponse>;

    public sealed record GetByEmailUser (string? Email) : IRequest< UserResponse>;
}
