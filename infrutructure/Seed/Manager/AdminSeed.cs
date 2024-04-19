using Domain.Entities.Role;
using Domain.Enum;
using infrutructure.Data.Manager;

namespace infrutructure.Seed.Manager;

public static class AdminSeed
{

    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Admins.Any(x=>!x.Name.Equals(RoleEnum.SuperAdmin.ToString())))
        {

            List<Role> roles = context.Roles.ToList();
            var admins = AdminFaker.GetBillFaker(roles).Generate(7).ToList();
            context.Admins.AddRange(admins);
            context.SaveChanges();

            
        }
    }
}