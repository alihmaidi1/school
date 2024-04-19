using Bogus;
using Domain.Entities.Student.Parent;
using Shared.Constant;

namespace infrutructure.Data.Student;

public static class ParentFaker
{

    public static Faker<Parent> GetBillFaker()
    {

        var ParentFaker = new Faker<Parent>();
        ParentFaker.RuleFor(x => x.Email, setter => setter.Internet.Email());
        ParentFaker.RuleFor(x => x.Password, setter => setter.Internet.Password());
        ParentFaker.RuleFor(x => x.Name, setter => setter.Random.Word());
        ParentFaker.RuleFor(x => x.Image,setter=>setter.Internet.Avatar());
        ParentFaker.RuleFor(x => x.Resize,setter=>setter.Internet.Avatar());
        ParentFaker.RuleFor(x => x.Hash, setter => setter.Random.String2(27,AlphaNumericWithSpicial.AlphaNumeric));
        return ParentFaker;
    }
}