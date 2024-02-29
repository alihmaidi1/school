using Common.Entity.ValueObject;

namespace Domain.Entities.Teacher.Teacher;

public class TeacherID:StronglyTypeId
{
    public TeacherID(Guid Value) : base(Value)
    {
    }
}