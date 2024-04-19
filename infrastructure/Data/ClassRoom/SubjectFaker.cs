using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.ClassRoom;

namespace infrastructure.Data.ClassRoom
{
    public static class SubjectFaker
    {


        public static Faker<Subject> GetFaker(List<Guid> Subjects)
        {

            var subject=new Faker<Subject>();
            subject.RuleFor(x=>x.Name,setter=>setter.Random.Words(1));
            subject.RuleFor(x=>x.ClassId,setter=>setter.PickRandom(Subjects));
            return subject;
            
        }


    }
}