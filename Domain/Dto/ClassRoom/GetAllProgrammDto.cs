using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom;

public class GetAllProgrammDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public List<Class> Classes{get;set;}


    public class Class{


        public Guid Id{get;set;}


        public string Name{get;set;}


        public List<Programm> Programm{get;set;}

    }



    public class Programm{


        public DayOfWeek Day{get;set;}
        public List<ProgrammInfo> ProgrammInfos{get;set;}


    }


    public class ProgrammInfo{


        public Guid SubjectId{get;set;}

        public TimeOnly StartAt{get;set;}

        public TimeOnly EndAt{get;set;}

    }
}
