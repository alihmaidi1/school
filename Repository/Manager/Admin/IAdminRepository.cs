using Domain.Entities.Manager.Admin;
using Dto.Admin.Admin;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Manager.Admin;

public interface IAdminRepository:IGenericRepository<Domain.Entities.Manager.Admin.Admin>
{


    public bool Delete(Guid id);


    public List<Guid> GetIds(string permission);
    
    
    
    
    public PageList<GetAllAdmin> GetAll(AdminSorting.OrderBy orderBy, int? pageNumber, int? pageSize,string? search);



    public GetAdminInfo GetInfo(Guid id);

    public bool Logout(string Token);

}