using Domain.Entities.Admin;
using Repository.Base;

namespace Repository.Manager.RefreshToken;

public interface IAdminRefreshTokenRepository:IgenericRepository<AdminRefreshTokenRepository>
{


    public bool IsExists(string Token);


}