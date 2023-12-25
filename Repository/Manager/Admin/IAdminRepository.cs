using Repository.Base;

namespace Repository.Manager.Admin;

public interface IAdminRepository:IgenericRepository<Domain.Entities.Admin.Admin>
{

    public bool IsEmailExists(string Email);


    public Domain.Entities.Admin.Admin GetByEmail(string Email);


    public bool Logout(string Token);

}