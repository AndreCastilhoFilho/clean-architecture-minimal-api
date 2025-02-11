using AutoMapper;
using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.DeleteUser;

public class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<UserRequest.DeleteUserRequest, User>();
        CreateMap<User, UserResponse>();
    }
}
