
using Common.Entity.ValueObject;

namespace Domain.Entities.Manager.Admin;

public class AdminID:StronglyTypeId
{
    public AdminID(Guid Value) : base(Value)
    {
    }
    

}