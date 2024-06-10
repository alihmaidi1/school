using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;

namespace Domain.Entities.ClassRoom;

public class Banner:BaseEntity
{

    public Banner(){

        Id=Guid.NewGuid();

    }


    public string Name{get;set;}


    public DateTimeOffset StartAt{get;set;}

    public DateTimeOffset EndAt{get;set;}

    public string Url{get;set;}

    public string Image{get;set;}

}
