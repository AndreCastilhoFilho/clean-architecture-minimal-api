using AutoMapper;
using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetAllUsers;

public sealed class GetAllUsersHandler : IRequestHandler<UserRequest.GetAllUsersRequest, List<UserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    async Task<List<UserResponse>> IRequestHandler<UserRequest.GetAllUsersRequest, List<UserResponse>>.Handle(UserRequest.GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<UserResponse>>(users);
    }
}
