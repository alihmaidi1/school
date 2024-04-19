using Bogus;
using Domain.Entities.Manager.Admin;
using Shared.Constant;
using Shared.Helper;

namespace infrastructure.Data.Manager;

public static class AdminFaker
{
    
    public static Faker<Admin> GetBillFaker(List<Guid> roles)
    {

        var adminFaker = new Faker<Admin>();
        adminFaker.RuleFor(x => x.Name, setter => setter.Random.Word());
        adminFaker.RuleFor(x => x.Email, setter => setter.Internet.Email());
        adminFaker.RuleFor(x => x.Password, setter => PasswordHelper.HashPassword(setter.Internet.Password()));
        adminFaker.RuleFor(x => x.RoleId, setter => setter.PickRandom(roles));
        adminFaker.RuleFor(x => x.Status, setter => setter.Random.Bool());
        adminFaker.RuleFor(x => x.Image, setter => setter.Internet.Avatar());
        adminFaker.RuleFor(x => x.Hash, setter=>setter.Random.String2(27,AlphaNumericWithSpicial.AlphaNumeric));
        return adminFaker;


    }
}