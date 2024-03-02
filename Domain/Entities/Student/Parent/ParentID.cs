using Common.Entity.ValueObject;

namespace Domain.Entities.Student.Parent;

public class ParentID:StronglyTypeId
{
    public ParentID(Guid Value) : base(Value)
    {
    }
    
    
}