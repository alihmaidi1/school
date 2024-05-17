using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

public class Program: BaseEntity
{

    public Program(){

        Id=Guid.NewGuid();
    }

    public DayOfWeek Day{get;set;}

    public TimeOnly StartAt{get;set;}


    public TimeOnly EndAt{get;set;}

    public Guid SubjectYearId{get;set;}

    public SubjectYear SubjectYear{get;set;}

}
