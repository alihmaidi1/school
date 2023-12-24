using Domain.Base.Entity;

namespace Domain.Entities.Role;

public class Role:BaseEntity<RoleID>
{
    
    
    public Role()
    {

        Id = new RoleID(Guid.NewGuid());
        Admins = new HashSet<Admin.Admin>();
    }

    public string Name { get; set; }

    public virtual ICollection<Admin.Admin>? Admins { get; set; }
    public string Permissions { get; set; }
    
}