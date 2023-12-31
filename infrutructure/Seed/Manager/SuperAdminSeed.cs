using Domain.Entities.Admin;
using Domain.Entities.Role;
using Domain.Enum;

namespace infrutructure.Seed.Manager;

public static class SuperAdminSeed
{
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Admins.Any())
        {

            List<string> Permissions = Enum.GetNames(typeof(PermissionEnum)).ToList();
            Role role = new Role()
            {

                Name = RoleEnum.SuperAdmin.ToString(),
                
                 Permissions = Permissions

            };
            Admin SuperAdmin = new Admin()
            {
                Name =RoleEnum.SuperAdmin.ToString(),
                Email = "SuperAdmin@gmail.com",
                Password = "12345678",
                Role = role

            };

            context.Admins.Add(SuperAdmin);
            context.SaveChanges();

        }
        
    }
}