using Domain.Entities.Student.Parent;
using Domain.Entities.Student.Student;
using infrastructure.Data.Student;
using Shared.Helper;

namespace infrastructure.Seed.Student;

public class StudentSeed
{
    
    public static async Task seedData(ApplicationDbContext context)
    {
        if (!context.Students.Any())
        {

            List<Guid> parents = context.Parents.Select(x=>x.Id).ToList();
            var Students = StudentFaker.GetBillFaker(parents).Generate(3);
            
            context.Students.AddRange(Students);

            var student=new Domain.Entities.Student.Student.Student(){

                Name="student",
                Email="student@gmail.com",
                Password=PasswordHelper.HashPassword("12345678"),
                Gender=true,
                Number=1233453,
                Level=1,
                ParentId=parents.First()

            };

            context.Students.Add(student);
            context.SaveChanges();
        }
    }
}