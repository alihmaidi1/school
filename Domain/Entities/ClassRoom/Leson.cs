using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

public class Leson: BaseEntity
{


    public Leson(){

        Id=Guid.NewGuid();
    }


    public string Name{get;set;}


    public string Url{get;set;}


    public Guid SubjectYearId{get;set;}

    public SubjectYear SubjectYear{get;set;}


}
