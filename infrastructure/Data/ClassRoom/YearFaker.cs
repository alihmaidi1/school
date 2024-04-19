using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.ClassRoom;

namespace infrastructure.Data.ClassRoom;

    public class YearFaker
    {


        public static Faker<Year> GetFaker(){


            var Year=new Faker<Year>();
            Year.RuleFor(x=>x.Date,setter=>DateTime.Now.AddYears(setter.Random.Int(-10,0)));
            return Year;

        }


    }
