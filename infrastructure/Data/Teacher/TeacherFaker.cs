using Bogus;
using Shared.Constant;
using Shared.Helper;

namespace infrastructure.Data.Teacher;

public static class TeacherFaker
{
    
    public static Faker<Domain.Entities.Teacher.Teacher.Teacher> GetBillFaker()
    {

        var Teacher =new Faker<Domain.Entities.Teacher.Teacher.Teacher>();
        Teacher.RuleFor(x=>x.Name,setter=>setter.Name.FindName());
        Teacher.RuleFor(x => x.Email, setter => setter.Internet.Email());
        Teacher.RuleFor(x=>x.Image,setter=>setter.Internet.Avatar());
        Teacher.RuleFor(x => x.Hash, setter => setter.Random.String2(27,AlphaNumericWithSpicial.AlphaNumeric));
        Teacher.RuleFor(x => x.Password,setter=> PasswordHelper.HashPassword("12345678"));
        
        return Teacher;


    }
}