using System.Linq.Expressions;
using Domain.Dto.Manager.Admin;
using Domain.Dto.Manager.Role;
using Domain.Enum;

namespace Repository.Manager.Role;

public static class RoleQuery
{
    
    // public static Expression<Func<Domain.Entities.Role.Role, GetAllRoleDto>> ToGetAllRole = role =>
        
    public static Expression<Func<Domain.Entities.Manager.Admin.Admin, GetAllAdminByRoleDto>> ToGetAllAdmin = admin =>
        new GetAllAdminByRoleDto
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