using Common.Entity.ValueObject;

namespace Domain.Entities.Teacher.Vacation;

public class VacationID:StronglyTypeId
{
    public VacationID(Guid Value) : base(Value)
    {
    }
}