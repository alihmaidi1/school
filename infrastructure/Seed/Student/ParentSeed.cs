using Domain.Entities.Student.Parent;
using infrastructure.Data.Student;
using Microsoft.AspNetCore.Identity;
using Shared.Helper;

namespace infrastructure.Seed.Student;

public static class ParentSeed
{

    public static async Task seedData(ApplicationDbContext context)
    {
        if (!context.Parents.Any())
        {
            var Parents = ParentFaker.GetBillFaker().Generate(3);
            context.Parents.AddRange(Parents);
            var Parent=new Parent{
                Name="parent",
                Email="parent@gmail.com",
                Password=PasswordHelper.HashPassword("12345678"),
            };

            context.Parents.Add(Parent);
            context.SaveChanges();
        }
    }

}