using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entity.EntityOperation;

namespace Domain.Dto.Session;
public class GetSessionWithExistsStudentDto
{

    public bool Status{get;set;}

    public PageList<Session> Sessions{get;set;}

    public class Session{


        public int SessionNumber{get;set;}

        public int ExistsCount{get;set;}


        public List<Student> Students{get;set;}

        public class Student{


            public Guid Id{get;set;}

            public string Name{get;set;}

            public bool Status{get;set;}
        }

    }

    


}
