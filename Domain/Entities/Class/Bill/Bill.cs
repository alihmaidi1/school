using Common.Entity.Entity;
using Domain.Entities.Class.Bill;
using Domain.Entities.Class.ClassYear;
using Domain.Entities.Class.StudentBill;

namespace ClassDomain.Entities.Bill;

public class Bill:BaseEntity<BillID>
{

    public Bill()
    {
        Id = new BillID(Guid.NewGuid());
        StudentBills = new HashSet<StudentBill>();
        StudentClasses = new HashSet<StudentClass.StudentClass>();

    }
    
    public float Money { get; set; }
    public ICollection<StudentClass.StudentClass> StudentClasses { get; set; }
    
    public ICollection<StudentBill> StudentBills { get; set; }
    
    public DateTime Date { get; set; }
    public ClassYearID ClassYearId { get; set; }
    public ClassYear ClassYear { get; set; }
}