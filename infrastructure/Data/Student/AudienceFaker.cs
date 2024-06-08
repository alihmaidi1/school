using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Student.Audience;

namespace infrastructure.Data.Student;

public static class AudienceFaker
{


    public static Faker<Audience> GetFaker()
    {

        var Audience=new Faker<Audience>();

        return Audience;


    }

}
