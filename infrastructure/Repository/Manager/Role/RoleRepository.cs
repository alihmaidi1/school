using Domain.Dto.Manager.Admin;
using Domain.Dto.Manager.Role;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using Domain.Enum;
using infrastructure;
using infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;

namespace Repository.Manager.Role;

public class RoleRepository:GenericRepository<Domain.Entities.Role.Role>,IRoleRepository
{
    public RoleRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }


    public PageList<GetAllRoleDto> GetAll(int? pageNumber, int? pageSize,string? Search)
    {
        var Permissions=Enum.GetNames(typeof(Domain.Enum.PermissionEnum)).Order().ToList();
        var Result = DbContext.Roles
            .Where(x => !x.Name.Equals(RoleEnum.SuperAdmin.ToString()))
            .Where(x=>x.Name.Contains(Search??""))            
            // .Sort<Domain.Entities.Role.Role>(OrderBy, RoleSorting.switchOrdering)
            .AsEnumerable()
            !.Select(x=>new GetAllRoleDto{
                Id = x.Id,
                Name = x.Name,
                Permissions = Permissions.Select(y=>new GetAllRoleDto.Permission{

                    Name=y,
                    Status=x.Permissions.Any(x=>x.Equals(y))

                }).ToList(),
                CreatedAt = x.DateCreated
            })
            .ToPagedList(pageNumber, pageSize);
        return Result;

        
    }



    // public bool IsExists(string Name,Guid roleId)
    // {

    //     return DbContext.Roles.Any(x=>x.Name.Equals(Name)&&!x.Id.Equals(roleId));
    // }

    public PageList<GetAllAdminByRoleDto> GetAdminById(Guid Id, int? pageNumber, int? pageSize,string? Search)
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