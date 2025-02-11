using AutoMapper;
using CleanArchitecture.Application.Shared.UserCQRS;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.DeleteUser;

public class DeleteUserHandler : IRequestHandler<UserRequest.DeleteUserRequest, UserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserResponse> Handle(UserRequest.DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id, cancellationToken);

        if (user == null) return default!;

        _userRepository.Delete(user);

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<UserResponse>(user);
    }
}
