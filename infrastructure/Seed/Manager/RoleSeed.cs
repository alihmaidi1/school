using Domain.Enum;
using infrastructure.Data.Manager;

namespace infrastructure.Seed.Manager;

public static class RoleSeed
{

    public static Task SeedData(ApplicationDbContext context)
    {
        if (!context.Roles.Any())
        {

            List<string> permissions = Enum.GetNames(typeof(PermissionEnum)).ToList();
            var roles = RoleFaker.GetBillFaker(permissions).Generate(5).ToList();
            context.Roles.AddRange(roles);
            context.SaveChanges();



        }

        return Task.CompletedTask;
    }

}