using Common.Entity.Entity;
using Shared.Entity.Entity;

namespace Domain.Entities.Role;

public class Role:BaseEntity
{
    
    
    public Role()
    {

        Id = Guid.NewGuid();
        Admins = new HashSet<Manager.Admin.Admin>();
    }

    public string Name { get; set; }

    public  ICollection<Manager.Admin.Admin> Admins { get; set; }
    public List<string> Permissions { get; set; }

}