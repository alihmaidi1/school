using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom;

public class GetAllStageAndClassesDto
{
    public Guid Id{get;set;}

    public string Name{get;set;}

    public List<Classes> Class{get;set;}    

    public class Classes{


        public Guid Id{get;set;}

        public string Name{get;set;}

    }

}
