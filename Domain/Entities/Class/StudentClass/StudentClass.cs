using Common.Entity.Entity;
using Domain.Entities.Class.ClassYear;
using Domain.Entities.Class.StudentBill;
using Domain.Entities.Class.StudentClass;
using Domain.Entities.Student.Student;

namespace ClassDomain.Entities.StudentClass;

public class StudentClass:BaseEntity<StudentClassID>
{

    public StudentClass()
    {

        Id = new StudentClassID(Guid.NewGuid());
        Bills = new HashSet<Bill.Bill>();
        StudentBills = new HashSet<StudentBill>();

    }
    
    public StudentID StudentId { get; set; }
    public Student Student { get; set; }
    
    
    public ClassYearID ClassYearId { get; set; }
    public ClassYear ClassYear { get; set; }
    
    public ICollection<StudentBill> StudentBills { get; set; }
    
    public ICollection<Bill.Bill> Bills { get; set; }
}