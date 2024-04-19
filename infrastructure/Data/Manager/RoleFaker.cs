using Bogus;
using Domain.Entities.Role;

namespace infrastructure.Data.Manager;

public static class RoleFaker
{


    public static Faker<Role> GetBillFaker(List<string> permissions)
    {
        var roleFaker = new Faker<Role>();
        roleFaker.RuleFor(x => x.Name, setter => setter.Random.Word());
        roleFaker.RuleFor(x => x.Permissions, setter=>permissions.OrderBy(x=>Guid.NewGuid()).Take(setter.Random.Int(1,permissions.Count)).ToList());
        return roleFaker;

    }

}