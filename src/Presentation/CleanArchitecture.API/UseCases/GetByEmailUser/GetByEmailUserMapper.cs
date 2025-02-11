using AutoMapper;
using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application;

public sealed class GetByEmailUserMapper : Profile
{
    public GetByEmailUserMapper()
    {
        CreateMap<UserRequest.GetByEmailUser, User>();
        CreateMap<User, UserResponse>();
    }
}
