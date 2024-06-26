using Domain.Base.interfaces;
using Domain.Entities.ClassRoom;
using Domain.Event;

namespace Domain.Entities.Teacher.Teacher;

public class Teacher: Account.Account,ISoftDelete
{
    public Teacher()
    {
        Id = Guid.NewGuid();
        Vacations = new HashSet<Vacation.Vacation>();
        Warnings = new HashSet<Warning.Warning>();
        // SubjectYears=new HashSet<SubjectYear>();

        TeacherSubjects=new HashSet<TeacherSubject>();
    }
    
    public void SendEmail(string Subject,string Message){

        RaiseDomainEvent(new SendEmailEvent{

            Email=Email,
            Subject=Subject,
            Message=Message
        });
    }
    
    
    
    
    public string? ResetCode { get; set; }
    
    
    public string ? Image { get; set; }    
    public string ? Hash { get; set; }

 
    public string? Reason{get;set;}
    public ICollection<Vacation.Vacation> Vacations { get; set; }
    public ICollection<Warning.Warning> Warnings { get; set; }
    // public ICollection<SubjectYear> SubjectYears{get;set;} 

    public ICollection<TeacherSubject> TeacherSubjects{get;set;}


}