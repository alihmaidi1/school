using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Account;
using Domain.Entities.Quez;
using Domain.Event;

namespace Domain.Entities.Student.Student;

public class Student:Domain.Entities.Account.Account
{
    public Student()
    {

        Id = Guid.NewGuid();

        StudentSubjects=new HashSet<StudentSubject.StudentSubject>();
        Audiences=new HashSet<Audience.Audience>();        
        StudentBills=new List<StudentBill.StudentBill>();
        StudentQuezs=new HashSet<StudentQuez>();

    }

        public void SendEmail(string Subject,string Message){

        RaiseDomainEvent(new SendEmailEvent(){

            Email=Email,
            Subject=Subject,
            Message=Message
            
        });

    }


    public int Level{get;set;}    
    


    
    public int Number { get; set; }
    
    public bool Gender { get; set; }
    
    
    public string? Image { get; set; }
    
    
    public string? Hash { get; set; }

    public string? Code{get;set;}
    

    public ICollection<StudentQuez> StudentQuezs{get;set;}
    public Guid ParentId { get; set; }
    public Parent.Parent Parent { get; set; }

    public ICollection<StudentSubject.StudentSubject> StudentSubjects{get;set;}


    public ICollection<Audience.Audience> Audiences{get;set;}

    public List<StudentBill.StudentBill> StudentBills{get;set;}
    
}