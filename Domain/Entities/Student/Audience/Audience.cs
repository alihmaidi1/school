using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.ClassRoom;
using Domain.Entities.Student.Student;
using Shared.Entity.Entity;

namespace Domain.Entities.Student.Audience;

public class Audience: BaseEntity
{


    public Audience(){

        Id=Guid.NewGuid();
    }

    public DateTimeOffset Date{get;set;}

    public bool IsExists{get;set;}


    public string? Reason{get;set;}


    public string? Image{get;set;}

    public string? Hash{get;set;}


    public Guid StudentId{get;set;}

    public Student.Student Student{get;set;}


    public int SessionNumber{get;set;}


    public Guid SubjectYearId{get;set;}

    public SubjectYear SubjectYear{get;set;}



}
