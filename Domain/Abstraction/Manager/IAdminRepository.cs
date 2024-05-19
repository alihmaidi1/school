using Domain.Abstraction;
using Domain.Dto.Manager.Admin;
using Domain.Entities.Manager.Admin;
using Domain.Enum.Ordering;
using Shared.Entity.EntityOperation;

namespace Repository.Manager.Admin;

public interface IAdminRepository:IGenericRepository<Domain.Entities.Manager.Admin.Admin>
{


    public bool Delete(Guid id);




    public List<Guid> GetIds(string permission);
    
    
    
    
    public PageList<GetAllAdminDto> GetAll(AdminSortEnum orderBy, int? pageNumber, int? pageSize,string? search);



    public GetAdminInfoDto GetInfo(Guid id);

    public bool Logout(string Token);

}