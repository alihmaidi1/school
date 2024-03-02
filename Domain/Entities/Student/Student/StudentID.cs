using Common.Entity.ValueObject;

namespace Domain.Entities.Student.Student;

public class StudentID:StronglyTypeId
{
    public StudentID(Guid Value) : base(Value)
    {
    }
    
    
}