using Common.Entity.ValueObject;

namespace Domain.Entities.Teacher.Warning;

public class WarningID:StronglyTypeId
{
    public WarningID(Guid Value) : base(Value)
    {
    }
    
}