using Dev.Core.Domain.Users;
using Dev.SharedKernel.Interfaces;
using MediatR;

namespace Dev.Core.UseCases.Users;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, User>
{
    private readonly IRepository<User> _userRepository;

    public GetUserByEmailHandler(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetUserByEmailSpec(request.Email);

        var entity = await _userRepository.FirstOrDefaultAsync(spec,
                                                                cancellationToken);
                               
        // if (entity == null)
        //     entity = new User();

        return entity;
    }
}
