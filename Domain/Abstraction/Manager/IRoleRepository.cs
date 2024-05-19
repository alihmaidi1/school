using Domain.Abstraction;
using Domain.Dto.Manager.Admin;
using Domain.Dto.Manager.Role;
using Shared.Entity.EntityOperation;

namespace Repository.Manager.Role;

public interface IRoleRepository:IGenericRepository<Domain.Entities.Role.Role>
{


    
    public PageList<GetAllAdminByRoleDto> GetAdminById(Guid Id, int? pageNumber, int? pageSize,string? Search);

    
    // public bool IsExists(string Name);

    // public bool IsExists(string Name,Guid roleId);

    public PageList<GetAllRoleDto> GetAll(int? pageNumber, int? pageSize,string? Search);

}