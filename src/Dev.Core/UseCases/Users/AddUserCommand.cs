using Dev.Core.Domain.Users;
using MediatR;

namespace Dev.Core.UseCases.Users;

public record AddUserCommand : IRequest<User>
{
    public AddUserCommand()
    {
        User = new User();
    }
    
    public User User { get; set; }
}