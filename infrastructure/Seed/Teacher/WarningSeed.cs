using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Warning;
using infrastructure.Data.Teacher;

namespace infrastructure.Seed.Teacher;

public static class WarningSeed
{
    
    public static async Task seedData(ApplicationDbContext context)
    {
        
        
        if (!context.Warnings.Any())
        {

            List<Domain.Entities.Teacher.Teacher.Teacher> teachers = context.Teachers.ToList();
            List<Admin> managers = context.Admins.ToList();
            List<Warning> warnings = WarningFaker.GetBrandFaker(teachers,managers).Generate(5);
            context.AddRange(warnings);
            context.SaveChanges();
        }

    }


    
}