using Common.Entity.ValueObject;

namespace Domain.Entities.Class.StudentClass;

public class StudentClassID:StronglyTypeId
{
    public StudentClassID(Guid Value) : base(Value)
    {
    }

}