using Common.Entity.ValueObject;

namespace Domain.Entities.Class.Year;

public class YearID:StronglyTypeId
{
    public YearID(Guid Value) : base(Value)
    {
    }
    
}