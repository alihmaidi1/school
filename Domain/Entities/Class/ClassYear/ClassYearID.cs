using Common.Entity.ValueObject;

namespace Domain.Entities.Class.ClassYear;

public class ClassYearID:StronglyTypeId
{
    public ClassYearID(Guid Value) : base(Value)
    {
    }
}