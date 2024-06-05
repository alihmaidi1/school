using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Teacher.Vacation;

namespace Domain.Entities.Teacher.Warning;

public class VacationType:BaseEntity,ISoftDelete
{


    public VacationType(){

        Id=Guid.NewGuid();

        Vacations=new HashSet<Vacation.Vacation>();
    }

    public string Name{get;set;}


    public ICollection<Vacation.Vacation> Vacations{get;set;}

}
