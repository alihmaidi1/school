using infrutructure.Data.Class;

namespace infrutructure.Seed.Class;

public static class YearSeed
{

    public static async Task seedData(ApplicationDbContext context)
    {


        if (!context.Years.Any())
        {
            var Years = YearFaker.GetBillFaker().Generate(20).DistinctBy(x=>x.Name);
            context.Years.AddRange(Years);
            context.SaveChanges();
        }


    }
}