using Common.Entity.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Student.Audience;
using Domain.Entities.Student.Parent;
using Domain.Entities.Student.StudentSubject;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Shared.Entity.Entity;

namespace Domain.Entities.Student.Student;

public class Student:BaseEntity,ISoftDelete
{
    public Student()
    {

        Id = Guid.NewGuid();

        StudentSubjects=new HashSet<StudentSubject.StudentSubject>();
        Audiences=new HashSet<Audience.Audience>();        
        StudentBills=new List<StudentBill.StudentBill>();

    }
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    

    public string Password { get; set; }
    
    public int Number { get; set; }
    
    public bool Gender { get; set; }
    
    
    public string? Image { get; set; }
    
    public string? Resize { get; set; }
    
    
    public string? Hash { get; set; }
    
    public Guid ParentId { get; set; }
    public Parent.Parent Parent { get; set; }

    public ICollection<StudentSubject.StudentSubject> StudentSubjects{get;set;}


    public ICollection<Audience.Audience> Audiences{get;set;}

    public List<StudentBill.StudentBill> StudentBills{get;set;}
    
}