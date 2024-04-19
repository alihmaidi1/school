using System.Linq.Expressions;
using Dto.Admin.Admin;

namespace Repository.Manager.Admin;

public static class AdminQuery
{
    public static readonly Expression<Func<Domain.Entities.Manager.Admin.Admin, GetAllAdmin>> ToGetAllAdmin = admin =>
        new GetAllAdmin
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