using ClassDomain.Entities.StudentClass;
using Domain.Entities.Class.ClassYear;
using infrutructure.Data.Class;

namespace infrutructure.Seed.Class;

public static class StudentClassSeed
{
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.StudentClasses.Any())
        {

            List<Domain.Entities.Student.Student.Student> students = context.Students.ToList();
            List<ClassYear> classYears = context.ClassYears.ToList();
            List<StudentClass> studentClasses=StudentClassFaker
                .GetStudentClassFaker(students,classYears)
                .Generate(20)
                .DistinctBy(x=>new {x.ClassYearId,x.StudentId})
                .ToList();

            context.StudentClasses.AddRange(studentClasses);
            context.SaveChanges();
            
        }
    }
    
}