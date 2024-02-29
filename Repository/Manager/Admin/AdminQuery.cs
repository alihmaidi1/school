using System.Linq.Expressions;
using Dto.Admin.Admin;

namespace Repository.Manager.Admin;

public static class AdminQuery
{
    public static Expression<Func<Domain.Entities.Admin.Admin, GetAllAdmin>> ToGetAllAdmin = admin =>
        new GetAllAdmin
        {
            Id = admin.Id.Value,
            Name = admin.Name,
            Email = admin.Email,
            CreatedAt = admin.DateCreated,
            Status = admin.Status,
            Image = admin.Image,
            Resize = admin.Resize,
            Hash = admin.Hash
        };
    
}