using System.Linq.Expressions;
using Domain.Dto.Manager.Admin;

namespace Repository.Manager.Admin;

public static class AdminQuery
{
    public static readonly Expression<Func<Domain.Entities.Manager.Admin.Admin, GetAllAdminDto>> ToGetAllAdmin = admin =>
        new GetAllAdminDto
        {
            Id = admin.Id,
            Name = admin.Name,
            Email = admin.Email,
            CreatedAt = admin.DateCreated,
            Status = admin.Status,
            Image = admin.Image,
            Hash = admin.Hash,
            Role = admin.Role.Name
        };
    
}