using Bogus;
using Domain.Entities.Student.Parent;
using Shared.Constant;
using Shared.Helper;

namespace infrastructure.Data.Student;

public static class StudentFaker
{

    public static Faker<Domain.Entities.Student.Student.Student> GetBillFaker(List<Guid> parentIds)
    {

        var Student = new Faker<Domain.Entities.Student.Student.Student>();
        Student.RuleFor(x => x.Email, setter => setter.Internet.Email());
        Student.RuleFor(x => x.Password, setter => PasswordHelper.HashPassword("12345678"));
        Student.RuleFor(x => x.Name, setter => setter.Random.Word());
        Student.RuleFor(x => x.ParentId,setter=>setter.PickRandom(parentIds));
        Student.RuleFor(x => x.Gender, setter => setter.Random.Bool());
        Student.RuleFor(x => x.Number, setter => setter.Random.Number(1000, 100000));
        Student.RuleFor(x => x.Image,setter=>setter.Internet.Avatar());
        Student.RuleFor(x => x.Hash, setter => setter.Random.String2(27,AlphaNumericWithSpicial.AlphaNumeric));
        Student.RuleFor(x=>x.Level,setter=>setter.Random.Int(1,9));
        return Student;
    }

}