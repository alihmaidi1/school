using Common.Entity.Entity;
using Domain.Base.Entity;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using Domain.Entities.Teacher.Vacation;
using Domain.Entities.Teacher.Warning;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace Domain.Entities.Admin;

public class Admin:AccountEntity<AdminID>
{

    public Admin()
    {

        Id = new AdminID(Guid.NewGuid());
        RefreshTokens = new HashSet<AdminRefreshToken>();
        Vacations = new HashSet<Vacation>();
        Warnings = new HashSet<Warning>();
    }

    
    
    public string Name { get; set; }
    
    public bool Status { get; set; }
    public string Email { get; set; }
    
    public RoleID RoleId { get; set; }
    public  Role.Role Role { set; get; }
    
    public string? Image { get; set; }
    
    public string? Resize { get; set; }
    
    public string? Hash { get; set; }
    
    [EncryptColumn]

    public string Password { get; set; }
    
    public  ICollection<AdminRefreshToken>? RefreshTokens { get; set; }

    public ICollection<Vacation> Vacations { get; set; }
    public ICollection<Warning> Warnings { get; set; }
    
    
}