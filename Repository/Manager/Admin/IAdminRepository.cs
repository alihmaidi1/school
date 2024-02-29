using Domain.Entities.Manager.Admin;
using Dto.Admin.Admin;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Manager.Admin;

public interface IAdminRepository:IgenericRepository<Domain.Entities.Admin.Admin>
{

    public bool IsEmailExists(string Email);


    public Domain.Entities.Admin.Admin GetByEmail(string Email);
    
    
    public PageList<GetAllAdmin> GetAlladmin(string? OrderBy, int? pageNumber, int? pageSize);


    public bool IsExists(AdminID id);

    public GetAdminInfo GetInfo(AdminID id);

    public bool Logout(string Token);

}