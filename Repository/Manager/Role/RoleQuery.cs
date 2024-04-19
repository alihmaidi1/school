using System.Linq.Expressions;
using Dto.Admin.Admin;
using Dto.Admin.Role;
using GetAllAdminByRole = Dto.Admin.Role.GetAllAdminByRole;

namespace Repository.Manager.Role;

public static class RoleQuery
{
    
    public static Expression<Func<Domain.Entities.Role.Role, GetAllRole>> ToGetAllRole = role =>
        new GetAllRole
        {
            Id = role.Id,
            Name = role.Name,
            Permissions = role.Permissions,
            CreatedAt = role.DateCreated
        };

    public static Expression<Func<Domain.Entities.Manager.Admin.Admin, GetAllAdminByRole>> ToGetAllAdmin = admin =>
        new GetAllAdminByRole
        {
            Id = admin.Id,
            Name = admin.Name,
            Email = admin.Email,
            CreatedAt = admin.DateCreated,
            Status = admin.Status,
            Hash = admin.Hash,
            Image = admin.Image,
            
        };
    //
}