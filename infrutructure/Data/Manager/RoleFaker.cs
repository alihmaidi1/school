using Bogus;
using Domain.Entities.Role;

namespace infrutructure.Data.Manager;

public static class RoleFaker
{


    public static Faker<Role> GetBillFaker(List<string> Permissions)
    {
        var RoleFaker = new Faker<Role>();
        List<string> NewPermissions = new List<string>();
        RoleFaker.RuleFor(x => x.Name, setter => setter.Random.Word());
        RoleFaker.RuleFor(x => x.Permissions, setter=>Permissions);
        return RoleFaker;

    }

}