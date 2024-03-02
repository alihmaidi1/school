using ClassDomain.Entities.StudentClass;
using Common.Entity.Entity;
using Domain.Entities.Class.ClassYear;
using Domain.Entities.Student.Parent;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace Domain.Entities.Student.Student;

public class Student:BaseEntity<StudentID>
{
    public Student()
    {

        Id = new StudentID(Guid.NewGuid());
        StudentClasses = new HashSet<StudentClass>();
        ClassYears = new HashSet<ClassYear>();
    }
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    
    [EncryptColumn]

    public string Password { get; set; }
    
    public int Number { get; set; }
    
    public bool Gender { get; set; }
    
    
    public string? Image { get; set; }
    
    public string? Resize { get; set; }
    
    
    public string? Hash { get; set; }
    
    public ParentID ParentId { get; set; }
    public Parent.Parent Parent { get; set; }
    
    public ICollection<ClassYear> ClassYears { get; set; }
    
    public ICollection<StudentClass> StudentClasses { get; set; }
}