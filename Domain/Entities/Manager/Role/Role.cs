using Domain.Base.Entity;

namespace Domain.Entities.Role;

public class Role:BaseEntity<RoleID>
{
    
    
    public Role()
    {

        Id = new RoleID(Guid.NewGuid());
    }

    public string Name { get; set; }
    
    public string Permissions { get; set; }
    
}