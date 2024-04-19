using Bogus;
using ClassDomain.Entities.StudentClass;
using Domain.Entities.Class.ClassYear;

namespace infrutructure.Data.Class;

public static class StudentClassFaker
{
    public static Faker<StudentClass> GetStudentClassFaker(List<Domain.Entities.Student.Student.Student> students,List<ClassYear> classYears)
    {

        var studentClass = new Faker<StudentClass>();
        studentClass.RuleFor(x => x.ClassYearId, setter => setter.PickRandom(classYears).Id);
        studentClass.RuleFor(x => x.StudentId, setter => setter.PickRandom(students).Id);
        return studentClass;

    }

    
    
}