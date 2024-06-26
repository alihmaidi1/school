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

            List<Guid> Subjects=context.Subjects.Select(x=>x.Id).ToList();
            List<Domain.Entities.Teacher.Teacher.Teacher> teachers = TeacherFaker.GetBillFaker(Subjects).Generate(5);
            context.AddRange(teachers);

            var Teacher=new Domain.Entities.Teacher.Teacher.Teacher(){

                Name="sdfsd",
                Email="teacher@gmail.com",
                Password=PasswordHelper.HashPassword("12345678"),

            };

            context.Teachers.Add(Teacher);
            context.SaveChanges();

            
        }
        
    }
    
}