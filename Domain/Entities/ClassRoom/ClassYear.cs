using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;

namespace Domain.Entities.ClassRoom;

public class ClassYear: BaseEntity
{

    public ClassYear(){

        Id=Guid.NewGuid();


        Bills=new HashSet<Bill>();
        SubjectYears=new HashSet<SubjectYear>();
    }


    public Guid ClassId{get;set;}


    public Class Class{get;set;}



    

    public Guid YearId{get;set;}

    public Year Year{get;set;}


    public bool Status{get;set;}=true;

    public ICollection<Bill> Bills{get;set;}


    public ICollection<SubjectYear> SubjectYears{get;set;}
}

