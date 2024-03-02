using Common.Entity.ValueObject;

namespace Domain.Entities.Class.StudentBill;

public class StudentBillID:StronglyTypeId
{
    public StudentBillID(Guid Value) : base(Value)
    {
    }
    
}