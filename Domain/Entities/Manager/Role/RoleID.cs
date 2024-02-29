using Common.Entity.ValueObject;
namespace Domain.Entities.Role;

public class RoleID:StronglyTypeId
{
    
    public RoleID(Guid Value) : base(Value)
    {
    }

    
}