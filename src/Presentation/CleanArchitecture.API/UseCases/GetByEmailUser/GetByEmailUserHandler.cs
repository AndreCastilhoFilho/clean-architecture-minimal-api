using AutoMapper;
using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetByEmailUser;

public sealed class GetByEmailUserHandler : IRequestHandler<UserRequest.GetByEmailUser, UserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetByEmailUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(UserRequest.GetByEmailUser request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if(user == null) return default!;

        return _mapper.Map<UserResponse>(user);
    }
}
