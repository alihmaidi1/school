using Domain.Base.Entity;
using Domain.Entities.Admin;
using Domain.Entities.Role;

namespace Domain.Entities.Manager;

public class AdminRole:BaseEntityWithoutId
{

    public AdminID AdminId { get; set; }
    
    public RoleID RoleId { get; set; }

}