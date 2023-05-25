using Dev.Core.Domain.Users;
using MediatR;

namespace Dev.Core.UseCases.Users;

public record GetUserByEmailQuery(string Email) : IRequest<User>;
