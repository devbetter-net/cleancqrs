using Ardalis.Specification;
using Dev.Core.Domain.Users;

namespace Dev.Core.UseCases.Users;

public class GetUserByEmailSpec: Specification<User>, ISingleResultSpecification
{
    public GetUserByEmailSpec(string email)
    {
        Query.Where(user => user.Email == email);
    }
}
