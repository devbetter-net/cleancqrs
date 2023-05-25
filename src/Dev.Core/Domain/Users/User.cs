using Dev.SharedKernel;
using Dev.SharedKernel.Interfaces;

namespace Dev.Core.Domain.Users;

public class User : BaseEntity, IAggregateRoot
{
    public User()
    {
        UserName = string.Empty;
        Email = string.Empty;
        Id = Guid.NewGuid();
        Deleted = false;
        CreatedOnUtc = DateTime.UtcNow;
        LastActivityDateUtc = DateTime.UtcNow;
        LastIpAddress = "127.0.0.1";
    }
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public int FailedLoginAttempts { get; set; }
    public bool Active { get; set; }
    public bool Deleted { get; set; }
    public string LastIpAddress { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? LastLoginDateUtc { get; set; }
    public DateTime LastActivityDateUtc { get; set; }
}
