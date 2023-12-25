using Domain.Base.Entity;
using Domain.Base.ValueObject;
using Domain.Entities.Role;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace Domain.Entities.Admin;

public class Admin:AccountEntity<AdminID>
{

    

    public Admin()
    {

        Id = new AdminID(Guid.NewGuid());

        RefreshTokens = new HashSet<AdminRefreshToken>();
    }

    
    
    public string Name { get; set; }
    
    public string Email { get; set; }

    public RoleID RoleId { get; set; }
    public  Role.Role Role { set; get; }
    
    
    [EncryptColumn]

    public string Password { get; set; }
    
    public  ICollection<AdminRefreshToken>? RefreshTokens { get; set; }

    
}