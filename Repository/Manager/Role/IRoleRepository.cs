using Domain.Entities.Role;
using Dto.Admin.Role;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Manager.Role;

public interface IRoleRepository:IGenericRepository<Domain.Entities.Role.Role>
{


    
    public PageList<GetAllAdminByRole> GetAdminById(Guid Id, int? pageNumber, int? pageSize,string? Search);

    
    // public bool IsExists(string Name);

    // public bool IsExists(string Name,Guid roleId);

    public PageList<GetAllRole> GetAll(int? pageNumber, int? pageSize,string? Search);

}