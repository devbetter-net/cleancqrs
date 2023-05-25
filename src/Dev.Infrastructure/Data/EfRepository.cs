using Ardalis.Specification.EntityFrameworkCore;
using Dev.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dev.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(DevContext dbContext) : base(dbContext)
    {
    }

}
