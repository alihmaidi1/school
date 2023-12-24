using Domain.Base.Entity;
using Domain.Entities.Role;
namespace Domain.Entities.Admin;

public class Admin:BaseEntity<AdminID>
{


    public Admin()
    {

        Id = new AdminID(Guid.NewGuid());
        
    }
    
    
    public string Name { get; set; }
    
    public string Email { get; set; }

    public RoleID RoleId { get; set; }
    public virtual Role.Role Role { set; get; }
    
    public string Password { get; set; }

    
}