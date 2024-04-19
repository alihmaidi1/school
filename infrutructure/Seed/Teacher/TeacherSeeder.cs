using infrutructure.Data.Teacher;

namespace infrutructure.Seed.Teacher;

public static class TeacherSeeder
{


    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Teachers.Any())
        {
            List<Domain.Entities.Teacher.Teacher.Teacher> teachers = TeacherFaker.GetBillFaker().Generate(10);
            context.AddRange(teachers);
            context.SaveChanges();

            
        }
        
    }
    
}