using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using Domain.Enum;
using Shared.Helper;

namespace infrastructure.Seed.Manager;

public static class SuperAdminSeed
{
    public static Task SeedData(ApplicationDbContext context)
    {
        if (!context.Admins.Any())
        {

            List<string> permissions = Enum.GetNames(typeof(PermissionEnum)).ToList();
            permissions.Add("Role");
            permissions.Add("Admin");

            Role role = new Role()
            {

                Name = RoleEnum.SuperAdmin.ToString(),
                 Permissions = permissions

            };
            Admin superAdmin = new Admin()
            {
                Name =RoleEnum.SuperAdmin.ToString(),
                Email = "SuperAdmin@gmail.com",
                Password = PasswordHelper.HashPassword("12345678"),
                Role = role

            };

            context.Admins.Add(superAdmin);
            context.SaveChanges();

        }

        return Task.CompletedTask;
    }
}