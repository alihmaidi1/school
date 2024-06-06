using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.ClassRoom;

namespace infrastructure.Data.ClassRoom;

public class LesonFaker
{

    public static Faker<Leson> GetFaker(Guid SubjectYears){

        var Leson=new Faker<Leson>();

        Leson.RuleFor(x=>x.Name,setter=>setter.Random.Words(1));
        Leson.RuleFor(x=>x.Url,setter=>setter.System.FilePath());
        Leson.RuleFor(x=>x.SubjectYearId,setter=>SubjectYears);
        return Leson;
        

    }
   

}
