using Common.Entity.ValueObject;

namespace Domain.Entities.Class.Bill;

public class BillID:StronglyTypeId
{
    public BillID(Guid Value) : base(Value)
    {
    }
    
        

}