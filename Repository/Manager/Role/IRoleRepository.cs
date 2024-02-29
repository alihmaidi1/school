using Domain.Entities.Role;
using Dto.Admin.Role;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Manager.Role;

public interface IRoleRepository:IgenericRepository<Domain.Entities.Role.Role>
{

    public bool IsExists(RoleID id);

    
    public PageList<GetAllAdminByRole> GetAdminById(RoleID Id, string? OrderBy, int? pageNumber, int? pageSize);

    
    public bool IsExists(string Name);

    public bool IsExists(string Name,RoleID roleId);

    public PageList<GetAllRole> GetAll(string? OrderBy, int? pageNumber, int? pageSize);

}