using Domain.Entities.Class.Year;
using infrutructure.Data.Class;

namespace infrutructure.Seed.Class;

public static class ClassYearSeeder
{
    
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.ClassYears.Any())
        {

            List<Year> years = context.Years.ToList();
            List<Domain.Entities.Class.Class.Class> classes = context.Classes.ToList();
            var classYears = ClassYearFaker
                .GetClassYearFaker(classes,years)
                .Generate(25)
                .DistinctBy(x=>new {x.ClassId,x.YearId})
                .ToList();
            context.ClassYears.AddRange(classYears);
            context.SaveChanges();

        }
        


    }

    
    
}