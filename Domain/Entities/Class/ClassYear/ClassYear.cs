using Common.Entity.Entity;
using Domain.Entities.Class.Year;
using Domain.Entities.Subject.Class;

namespace Domain.Entities.Class.ClassYear;

public class ClassYear:BaseEntity<ClassYearID>
{
    public ClassYear()
    {

        Id = new ClassYearID(Guid.NewGuid());
        Bills = new HashSet<ClassDomain.Entities.Bill.Bill>();
        StudentClasses = new HashSet<ClassDomain.Entities.StudentClass.StudentClass>();
    }
    
    
    public YearID YearId { get; set; }
    
    public ClassID ClassId { get; set; }
    
    
    public Class.Class Class { get; set; }
    
    
    public Year.Year Year { get; set; }

    public ICollection<ClassDomain.Entities.StudentClass.StudentClass> StudentClasses { get; set; }

    public ICollection<Student.Student.Student> Students { get; set; }

    public ICollection<ClassDomain.Entities.Bill.Bill>  Bills { get; set; }

    
}