using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.ClassRoom;

namespace infrastructure.Data.ClassRoom;

    public class SubjectYearFaker
    {


        public static Faker<SubjectYear> GetFaker(){


            var SubjectYear =new Faker<SubjectYear>();
            // SubjectYear.RuleFor(x=>x.YearId,setter=>setter.PickRandom(Years));
            // SubjectYear.RuleFor(x=>x.SubjectId,setter=>setter.PickRandom(Subject));
            // SubjectYear.RuleFor(x=>x.TeacherId,setter=>setter.PickRandom(Teachers));
            return SubjectYear;
        

        }   

    }
