using Dev.Core.Domain.Users;
using Dev.SharedKernel.Interfaces;
using MediatR;

namespace Dev.Core.UseCases.Users;

public class AddUserHandler : IRequestHandler<AddUserCommand, User>
{
    private readonly IRepository<User> _userRepository;

    public AddUserHandler(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.AddAsync(request.User);
        return request.User;
    }
}
