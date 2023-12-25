using infrutructure;
using Repository.Base;
using Repository.Manager.Admin;

namespace Repository.Manager.RefreshToken;

public class AdminRefreshTokenRepository:GenericRepository<AdminRefreshTokenRepository>,IAdminRefreshTokenRepository
{
    public AdminRefreshTokenRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(string Token)
    {


        return DbContext.AdminRefreshTokens.Any(x=>x.Token.Equals(Token));

    }
}