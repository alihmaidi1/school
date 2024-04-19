using Common.Entity.Entity;
using Domain.Entities.Account;
using Domain.Entities.ClassRoom;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Shared.Entity.Entity;

namespace Domain.Entities.Teacher.Teacher;

public class Teacher: Account.Account
{
    public Teacher()
    {
        Id = Guid.NewGuid();
        Vacations = new HashSet<Vacation.Vacation>();
        Warnings = new HashSet<Warning.Warning>();
        Subjects=new HashSet<Subject>();
        SubjectYears=new HashSet<SubjectYear>();
    }
    public string Name { get; set; }
    
    
    
    
    public string? ResetCode { get; set; }
    
    
    
    
    public bool Status { get; set; }
    
    
    public string ? Image { get; set; }
    
    public string ? Hash { get; set; }
    
    public ICollection<Vacation.Vacation> Vacations { get; set; }
    public ICollection<Warning.Warning> Warnings { get; set; }

    public ICollection<SubjectYear> SubjectYears{get;set;} 
    public ICollection<Subject> Subjects{get;set;}


}