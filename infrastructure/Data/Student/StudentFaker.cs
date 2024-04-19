using Bogus;
using Domain.Entities.Student.Parent;
using Shared.Constant;

namespace infrastructure.Data.Student;

public static class StudentFaker
{

    public static Faker<Domain.Entities.Student.Student.Student> GetBillFaker(List<Guid> parentIds)
    {

        var Student = new Faker<Domain.Entities.Student.Student.Student>();
        Student.RuleFor(x => x.Email, setter => setter.Internet.Email());
        Student.RuleFor(x => x.Password, setter => setter.Internet.Password());
        Student.RuleFor(x => x.Name, setter => setter.Random.Word());
        Student.RuleFor(x => x.ParentId,setter=>setter.PickRandom(parentIds));
        Student.RuleFor(x => x.Gender, setter => setter.Random.Bool());
        Student.RuleFor(x => x.Number, setter => setter.Random.Number(1000, 100000));
        Student.RuleFor(x => x.Image,setter=>setter.Internet.Avatar());
        Student.RuleFor(x => x.Resize,setter=>setter.Internet.Avatar());
        Student.RuleFor(x => x.Hash, setter => setter.Random.String2(27,AlphaNumericWithSpicial.AlphaNumeric));
        return Student;
    }

}