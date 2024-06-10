using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Parent;

public class GetAllParentStudentAudienceDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public List<Audience> Audiences{get;set;}


    public class Audience{


        public Guid Id{get;set;}

        public DateTimeOffset Date{get;set;}

        public int SessionNumber{get;set;}

        public string SubjectName{get;set;}




    }

}
