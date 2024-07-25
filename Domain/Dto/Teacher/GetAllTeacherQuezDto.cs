using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto.Admin.Teacher;

public class GetAllTeacherQuezDto
{


        public Guid Id {get;set;}


        public string Name{get;set;}


        public List<Quez> Quezies{get;set;}

        public class Quez{


            public Guid Id {get;set;}

            public bool Status{get;set;}
            public string Name{get;set;}

            public int QuestionNumber{get;set;}

            public DateTimeOffset StartAt{get;set;}      
            public DateTimeOffset EndAt{get;set;}      

            public int Student{get;set;}
        }

}
