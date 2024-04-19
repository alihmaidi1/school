using Domain.Entities.Teacher.Teacher;
using infrastructure.Data.Teacher;
using Shared.Helper;

namespace infrastructure.Seed.Teacher;

public static class TeacherSeeder
{


    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Teachers.Any())
        {
            // List<Domain.Entities.Teacher.Teacher.Teacher> teachers = TeacherFaker.GetBillFaker().Generate(5);
            // context.AddRange(teachers);
            var Teacher=new Domain.Entities.Teacher.Teacher.Teacher(){

                Email="teacher@gmail.com",
                Password=PasswordHelper.HashPassword("12345678"),
                Name="teacher",
                Image="dsf",
                Hash="sdfsfdsdfs"

            };
            context.Add(Teacher);
            context.SaveChanges();


            
        }
        
    }
    
}