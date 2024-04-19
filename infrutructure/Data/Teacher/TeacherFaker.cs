using Bogus;

namespace infrutructure.Data.Teacher;

public static class TeacherFaker
{
    
    public static Faker<Domain.Entities.Teacher.Teacher.Teacher> GetBillFaker()
    {

        var Teacher =new Faker<Domain.Entities.Teacher.Teacher.Teacher>();
        Teacher.RuleFor(x=>x.Name,setter=>setter.Name.FindName());
        Teacher.RuleFor(x => x.Email, setter => setter.Internet.Email());
        Teacher.RuleFor(x => x.Password, "12345678");
        Teacher.RuleFor(x => x.status, setter => setter.Random.Bool());
        Teacher.RuleFor(x => x.status, setter => setter.Random.Bool());
        
        

        return Teacher;


    }
}