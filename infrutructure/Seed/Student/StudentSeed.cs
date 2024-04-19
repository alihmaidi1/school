using Domain.Entities.Student.Parent;
using infrutructure.Data.Student;

namespace infrutructure.Seed.Student;

public class StudentSeed
{
    
    public static async Task seedData(ApplicationDbContext context)
    {
        if (!context.Students.Any())
        {

            List<ParentID> parents = context.Parents.Select(x=>x.Id).ToList();
            var Students = StudentFaker.GetBillFaker(parents).Generate(30);
            context.Students.AddRange(Students);
            context.SaveChanges();
        }
    }
}