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


    public class Subject{


        public string Name{get;set;}

        public float Mark{get;set;}

    }

}
