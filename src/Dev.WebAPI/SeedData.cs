using Dev.Core.Domain.Users;
using Dev.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dev.WebAPI;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new DevContext(
            serviceProvider.GetRequiredService<DbContextOptions<DevContext>>()))
        {
            PopulateTestData(dbContext);
        }
    }

    private static void PopulateTestData(DevContext dbContext)
    {
        var users = dbContext.Set<User>();
        if (users.Any())
        {
            return;
        }
        //seed
        foreach (var user in DemoUsers())
        {
            users.Add(user);
        }
        dbContext.SaveChanges();
    }

    private static List<User> DemoUsers(){
        List<User> listUser = new List<User>();
        listUser.Add(new User()
        {
            Id = Guid.NewGuid(),
            UserName = "User name 01",
            Email = "user01@user.com"
        });

        listUser.Add(new User()
        {
            Id = Guid.NewGuid(),
            UserName = "User name 02",
            Email = "user02@user.com"
        });

        listUser.Add(new User()
        {
            Id = Guid.NewGuid(),
            UserName = "User name 03",
            Email = "user03@user.com"
        });

        listUser.Add(new User()
        {
            Id = Guid.NewGuid(),
            UserName = "User name 04",
            Email = "user04@user.com"
        });

        listUser.Add(new User()
        {
            Id = Guid.NewGuid(),
            UserName = "User name 05",
            Email = "user05@user.com"
        });
        return listUser;
    }
}
