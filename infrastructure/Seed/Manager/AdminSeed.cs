using Domain.Entities.Role;
using Domain.Enum;
using infrastructure.Data.Manager;

namespace infrastructure.Seed.Manager;

public static class AdminSeed
{

    public static Task SeedData(ApplicationDbContext context)
    {
        if (!context.Admins.Any(x=>!x.Name.Equals(RoleEnum.SuperAdmin.ToString())))
        {
            
            
            List<Guid> roles = context.Roles.Where(x=>x.Name!="SuperAdmin").Select(x=>x.Id).ToList();
            var admins = AdminFaker.GetBillFaker(roles).Generate(7).ToList().DistinctBy(x=>x.Email);
            context.Admins.AddRange(admins);
            context.SaveChanges();
        }

        return Task.CompletedTask;
    }
}