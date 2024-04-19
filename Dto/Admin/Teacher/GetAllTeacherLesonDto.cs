using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto.Admin.Teacher;

public class GetAllTeacherLesonDto
{



        public Guid Id{get;set;}

        public string Name{get;set;}


        public List<Leson> Lesons{get;set;}




    public class Leson{


        public Guid Id{get;set;}

        public string Name{get;set;}

        public string Url{get;set;}

    }

}
