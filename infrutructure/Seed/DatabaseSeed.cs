using ClassDomain.Entities.StudentClass;
using Domain.Entities.Class.StudentBill;
using infrutructure.Seed.Class;
using infrutructure.Seed.Manager;
using infrutructure.Seed.Student;
using infrutructure.Seed.Teacher;
using Microsoft.Extensions.DependencyInjection;

namespace infrutructure.Seed;

public static class DatabaseSeed
{
    
    public static async Task InitializeAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var transaction = context.Database.BeginTransaction();

        try
        {
            
            await SuperAdminSeed.seedData(context);
            await RoleSeed.seedData(context);
            await AdminSeed.seedData(context);
            await TeacherSeeder.seedData(context);
            await VacationSeeder.seedData(context);
            await WarningSeed.seedData(context);
            await YearSeed.seedData(context);
            await StageSeed.seedData(context);
            await ParentSeed.seedData(context);
            await StudentSeed.seedData(context);
            await ClassYearSeeder.seedData(context);
            await BillSeeder.seedData(context);
            await StudentClassSeed.seedData(context);
            // await StudentBillSeed.seedData(context);
            await transaction.CommitAsync();

        }
        catch(Exception ex)
        {
            transaction.Rollback();
            throw new Exception(ex.Message);
        }
        
    }


}