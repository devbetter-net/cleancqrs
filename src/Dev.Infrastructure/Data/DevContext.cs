using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace Dev.Infrastructure.Data;

public class DevContext : DbContext
{
    //#pragma warning disable CS8618 // Required by Entity Framework
    public DevContext(DbContextOptions<DevContext> options) : base(options)
    {
        Database.EnsureCreated();   // add this to ensure new tables,colums are created
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //all query is no tracking. 
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    /// <summary>
    /// Limitation: this GenerateCreateScript() in Microsoft.EntityFrameworkCore.Relational package
    /// </summary>
    /// <returns></returns>
    public string GenerateCreateScript()
    {
        return Database.GenerateCreateScript();
    }
}
