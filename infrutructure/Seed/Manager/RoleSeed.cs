using Domain.Enum;
using infrutructure.Data.Manager;

namespace infrutructure.Seed.Manager;

public static class RoleSeed
{

    public static async Task seedData(ApplicationDbContext context)
    {
        
        
        if (!context.Roles.Any())
        {

            List<string> Permissions = Enum.GetNames(typeof(PermissionEnum)).ToList();
            var Roles = RoleFaker.GetBillFaker(Permissions).Generate(5).ToList();
            context.Roles.AddRange(Roles);
            context.SaveChanges();



        }

    }

}