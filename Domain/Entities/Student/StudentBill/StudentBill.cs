using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entity.Entity;

namespace Domain.Entities.Student.StudentBill;


public class StudentBill:BaseEntity
{

    public StudentBill(){


        Id=Guid.NewGuid();

    }


    public Guid StudentId{get;set;}


    public Student.Student Student{get;set;}

    public DateTime Date{get;set;}
    public float Money{get;set;}

    public float PaiedMoney{get;set;}

}
