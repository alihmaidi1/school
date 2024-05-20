using Domain.Entities.Student.Parent;
using infrastructure.Data.Student;

namespace infrastructure.Seed.Student;

public class StudentSeed
{
    
    public static async Task seedData(ApplicationDbContext context)
    {
        if (!context.Students.Any())
        {

            List<Guid> parents = context.Parents.Select(x=>x.Id).ToList();
            var Students = StudentFaker.GetBillFaker(parents).Generate(20);
            context.Students.AddRange(Students);
            context.SaveChanges();
        }
    }
}