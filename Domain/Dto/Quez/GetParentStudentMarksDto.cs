using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Quez;

public class GetParentStudentMarksDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public List<Subject> Marks{get;set;}

    public class Subject{


        public Guid Id{get;set;}

        public string SubjectName{get;set;}

        public List<Quez> Quezs{get;set;}




    }


    public class Quez{


        public Guid Id{get;set;}

        public string Name{get;set;}
        

        public float Mark{get;set;}

    }
}
