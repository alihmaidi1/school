using Domain.Entities.Quez;
using infrastructure.Seed.ClassRoom;
using infrastructure.Seed.Manager;
using infrastructure.Seed.Quez;
using infrastructure.Seed.Student;
using infrastructure.Seed.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure.Seed;

public static class DatabaseSeed
{
    
    public static async Task InitializeAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        // var pendingMigration = await context.Database.GetPendingMigrationsAsync();
        // if (!pendingMigration.Any())
        // {
        //     await context.Database.MigrateAsync();
        //     
        // }
        var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            
            await SuperAdminSeed.SeedData(context);
            await RoleSeed.SeedData(context);
            await AdminSeed.SeedData(context);
            await TeacherSeeder.seedData(context);
            // await VacationSeeder.seedData(context);
            // await WarningSeed.seedData(context);

            await YearSeeder.SeedData(context);
            await StageSeeder.SeedData(context);
            await SubjectSeeder.SeedData(context);
            await SubjectYearSeeder.SeedData(context);
            await ParentSeed.seedData(context);
            await StudentSeed.seedData(context);
            await StudentSubjectSeeder.seedData(context);
            await LesonSeeder.SeedData(context);
            await QuezSeeder.seedData(context);
            await StudentAnswerSeeder.seedData(context);





            // await StudentAnswerSeeder.seedData(context);
            // await ClassYearSeeder.seedData(context);
            // await BillSeeder.seedData(context);
            // await StudentClassSeed.seedData(context);
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