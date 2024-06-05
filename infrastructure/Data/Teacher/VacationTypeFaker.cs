using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Teacher.Warning;

namespace infrastructure.Data.Teacher;

public static class  VacationTypeFaker
{


    public static Faker<VacationType> GetVacationFaker()
    {

        var VacationType=new Faker<VacationType>();
        VacationType.RuleFor(x=>x.Name,setter=>setter.Random.Word());

        return VacationType;


    }

}
