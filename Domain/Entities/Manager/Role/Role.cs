
using Domain.Base.Entity;
using Domain.Base.interfaces;

namespace Domain.Entities.Role;

public class Role:BaseEntity,ISoftDelete
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