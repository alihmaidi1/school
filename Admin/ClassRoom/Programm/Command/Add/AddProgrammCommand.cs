using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.ClassRoom.Programm.Command.Add;

public class AddProgrammCommand: ICommand
{

    public Guid ClassId{get;set;}

    public List<Programm> Programms{get;set;}


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
