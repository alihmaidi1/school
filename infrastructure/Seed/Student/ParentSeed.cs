using infrastructure.Data.Student;

namespace infrastructure.Seed.Student;

public static class ParentSeed
{

    public static async Task seedData(ApplicationDbContext context)
    {
        if (!context.Parents.Any())
        {

            var Parents = ParentFaker.GetBillFaker().Generate(15);
            context.Parents.AddRange(Parents);
            context.SaveChanges();
        }
    }

}