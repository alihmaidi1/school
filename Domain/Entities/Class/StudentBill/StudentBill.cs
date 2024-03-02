using Common.Entity.Entity;
using Domain.Entities.Class.Bill;
using Domain.Entities.Class.StudentClass;

namespace Domain.Entities.Class.StudentBill;

public class StudentBill:BaseEntity<StudentBillID>
{

    public StudentBill()
    {
        Id = new StudentBillID(Guid.NewGuid());
        
    }
    public BillID BillId { get; set; }
    public ClassDomain.Entities.Bill.Bill Bill { get; set; }
    public ClassDomain.Entities.StudentClass.StudentClass StudentClass { get; set; }
    public StudentClassID StudentClassId { get; set; }
}