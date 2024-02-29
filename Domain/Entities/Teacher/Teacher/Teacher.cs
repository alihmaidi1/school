using Common.Entity.Entity;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace Domain.Entities.Teacher.Teacher;

public class Teacher:BaseEntity<TeacherID>
{
    public Teacher()
    {
        Id = new TeacherID(Guid.NewGuid());
        Vacations = new HashSet<Vacation.Vacation>();
        Warnings = new HashSet<Warning.Warning>();

    }
    public string Name { get; set; }
    public string Email { get; set; }
    
    
    
    [EncryptColumn]
    
    public string? ResetCode { get; set; }
    
    
    
    [EncryptColumn]
    public string Password { get; set; }
    //
    public bool status { get; set; }
    
    
    public string ? Image { get; set; }
    
    public string ? Hash { get; set; }
    public string ? Resize { get; set; }
    
    public ICollection<Vacation.Vacation> Vacations { get; set; }
    public ICollection<Warning.Warning> Warnings { get; set; }


}