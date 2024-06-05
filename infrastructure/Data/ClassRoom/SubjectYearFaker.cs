using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.ClassRoom;

namespace infrastructure.Data.ClassRoom;

    public class SubjectYearFaker
    {


        public static Faker<SubjectYear> GetFaker(List<Guid> ClassYears,List<Guid> TeacherSubjects){


            var SubjectYear =new Faker<SubjectYear>();
            SubjectYear.RuleFor(x=>x.ClassYearId,setter=>setter.PickRandom(ClassYears));
            SubjectYear.RuleFor(x=>x.TeacherSubjectId,setter=>setter.PickRandom(TeacherSubjects));

            return SubjectYear;
        

        }   

    }
