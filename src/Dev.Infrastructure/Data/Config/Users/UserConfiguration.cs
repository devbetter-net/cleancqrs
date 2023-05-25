using Dev.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Infrastructure.Data.Config.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.HasKey(k => k.Id);
        builder.HasIndex(i => i.Email).IsUnique();
        builder.Property(p => p.Email).HasMaxLength(250);
        builder.Property(p => p.FailedLoginAttempts).HasDefaultValue(1);
        builder.Property(p => p.Deleted).HasDefaultValue(false);
    }
}
