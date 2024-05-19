using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Event;

namespace Domain.Entities.Student.Student;

public class Student:BaseEntity
{
    public Student()
    {

        Id = Guid.NewGuid();

        StudentSubjects=new HashSet<StudentSubject.StudentSubject>();
        Audiences=new HashSet<Audience.Audience>();        
        StudentBills=new List<StudentBill.StudentBill>();

    }

        public void SendEmail(string Subject,string Message){

        RaiseDomainEvent(new SendEmailEvent(){

            Email=Email,
            Subject=Subject,
            Message=Message


            
        });

    }

    public string Name { get; set; }
    
    public string Email { get; set; }
    
    

    public string Password { get; set; }
    
    public int Number { get; set; }
    
    public bool Gender { get; set; }
    
    
    public string? Image { get; set; }
    
    
    public string? Hash { get; set; }
    
    public Guid ParentId { get; set; }
    public Parent.Parent Parent { get; set; }

    public ICollection<StudentSubject.StudentSubject> StudentSubjects{get;set;}


    public ICollection<Audience.Audience> Audiences{get;set;}

    public List<StudentBill.StudentBill> StudentBills{get;set;}
    
}