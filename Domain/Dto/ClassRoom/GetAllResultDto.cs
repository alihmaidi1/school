using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom;

public class GetAllResultDto
{

    public Guid Id{get;set;}

    public bool Status{get;set;}

    public string Name{get;set;}

    public float Precent{get;set;}

    public List<Subject> Subjects{get;set;}


    public class Subject{


        public Guid Id{get;set;}
        public string Name{get;set;}

        public float? Mark{get;set;}

    }

}
