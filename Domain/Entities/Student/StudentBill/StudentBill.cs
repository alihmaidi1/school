using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Entities.ClassRoom;
using Shared.Entity.Entity;

namespace Domain.Entities.Student.StudentBill;


public class StudentBill:BaseEntity
{

    public StudentBill(){


        Id=Guid.NewGuid();

    }


    public Guid StudentId{get;set;}


    public Student.Student Student{get;set;}

    public Guid BillId{get;set;}

    public Bill Bill{get;set;}

    public DateTimeOffset Date{get;set;}
    public float Money{get;set;}

    public float PaiedMoney{get;set;}=0;

}
