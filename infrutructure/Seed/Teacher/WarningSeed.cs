using Domain.Entities.Admin;
using Domain.Entities.Teacher.Warning;
using infrutructure.Data.Teacher;

namespace infrutructure.Seed.Teacher;

public static class WarningSeed
{
    
    public static async Task seedData(ApplicationDbContext context)
    {
        
        
        if (!context.Warnings.Any())
        {

            List<Domain.Entities.Teacher.Teacher.Teacher> teachers = context.Teachers.ToList();
            List<Admin> managers = context.Admins.ToList();
            List<Warning> warnings = WarningFaker.GetBrandFaker(teachers,managers).Generate(10);
            context.AddRange(warnings);
            context.SaveChanges();
        }

    }


    
}