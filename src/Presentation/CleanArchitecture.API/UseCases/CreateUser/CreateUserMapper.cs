using AutoMapper;
using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<UserRequest.CreateUserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}
