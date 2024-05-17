using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using Domain.Enum;
using Dto.Admin.Role;
using infrastructure;
using Repository.Base;
using Repository.Manager.Admin;
using Shared.Entity.EntityOperation;

namespace Repository.Manager.Role;

public class RoleRepository:GenericRepository<Domain.Entities.Role.Role>,IRoleRepository
{
    public RoleRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }


    public PageList<GetAllRole> GetAll(int? pageNumber, int? pageSize,string? Search)
    {
        
        var Result = DbContext.Roles
            .Where(x => !x.Name.Equals(RoleEnum.SuperAdmin.ToString()))
            .Where(x=>x.Name.Contains(Search??""))
            // .Sort<Domain.Entities.Role.Role>(OrderBy, RoleSorting.switchOrdering)
            !.Select(RoleQuery.ToGetAllRole)
            .ToPagedList(pageNumber, pageSize);
        return Result;

        
    }



    // public bool IsExists(string Name,Guid roleId)
    // {

    //     return DbContext.Roles.Any(x=>x.Name.Equals(Name)&&!x.Id.Equals(roleId));
    // }

    public PageList<GetAllAdminByRole> GetAdminById(Guid Id, int? pageNumber, int? pageSize,string? Search)
    {
        
        
        return  DbContext
            .Admins
            .Where(x => x.RoleId == Id)
            .Where(x=>x.Name.Contains(Search??""))
            .Where(x=>x.Email.Contains(Search??""))
            .Select(RoleQuery.ToGetAllAdmin)
            .ToPagedList(pageNumber, pageSize);
        
    
    }


}