using Bogus;
using Domain.Entities.Admin;
using Domain.Entities.Role;
using Shared.Constant;

namespace infrutructure.Data.Manager;

public static class AdminFaker
{
    
    public static Faker<Admin> GetBillFaker(List<Role> roles)
    {

        var AdminFaker = new Faker<Admin>();
        AdminFaker.RuleFor(x => x.Name, setter => setter.Random.Word());
        AdminFaker.RuleFor(x => x.Email, setter => setter.Internet.Email());
        AdminFaker.RuleFor(x => x.Password, setter => setter.Internet.Password());
        AdminFaker.RuleFor(x => x.RoleId, setter => setter.PickRandom(roles).Id);
        AdminFaker.RuleFor(x => x.Status, setter => setter.Random.Bool());
        AdminFaker.RuleFor(x => x.Image, setter => setter.Internet.Avatar());
        AdminFaker.RuleFor(x => x.Resize, setter => setter.Internet.Avatar());
        AdminFaker.RuleFor(x => x.Hash, setter=>setter.Random.String2(27,AlphaNumericWithSpicial.AlphaNumeric));
        return AdminFaker;


    }
}