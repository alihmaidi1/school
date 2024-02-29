using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using Domain.Enum;
using Dto.Admin.Role;
using infrutructure;
using Repository.Base;
using Repository.Manager.Admin;
using Shared.Entity.EntityOperation;
using Shared.Repository;

namespace Repository.Manager.Role;

public class RoleRepository:GenericRepository<Domain.Entities.Role.Role>,IRoleRepository
{
    public RoleRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(RoleID id)
    {
        
        return DbContext.Roles.Any(x => x.Id.Equals(id));
    }

    public PageList<GetAllRole> GetAll(string? OrderBy, int? pageNumber, int? pageSize)
    {
        
        var Result = DbContext.Roles
            .Where(x => !x.Name.Equals(RoleEnum.SuperAdmin.ToString()))
            .Sort<RoleID, Domain.Entities.Role.Role>(OrderBy, RoleSorting.switchOrdering)
            .Select(RoleQuery.ToGetAllRole)
            .ToPagedList(pageNumber, pageSize);
        return Result;

        
    }


    public bool IsExists(string Name)
    {

        return DbContext.Roles.Any(x => x.Name.Equals(Name));

    }

    public bool IsExists(string Name, RoleID roleId)
    {

        return DbContext.Roles.Any(x=>x.Name.Equals(Name)&&!x.Id.Equals(roleId));
    }

    public PageList<GetAllAdminByRole> GetAdminById(RoleID Id, string? OrderBy, int? pageNumber, int? pageSize)
    {
        
        
        var Result = DbContext.Admins
            .Where(x => x.RoleId == Id)
            .Sort<AdminID,Domain.Entities.Admin.Admin>(OrderBy, AdminSorting.switchOrdering)
            .Select(RoleQuery.ToGetAllAdmin)
            .ToPagedList(pageNumber, pageSize);

        return Result;
        
        
    }


}