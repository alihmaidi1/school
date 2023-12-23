using Domain.Base.Entity;

namespace Domain.Entities.Admin;

public class Admin:BaseEntity<AdminID>
{


    public Admin()
    {

        Id = new AdminID(Guid.NewGuid());
    }
    
    
    public string Name { get; set; }
    
    public string Email { get; set; }

    public string Password { get; set; }

    
}