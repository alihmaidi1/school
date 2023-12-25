using infrutructure;
using Repository.Base;
using Shared.Redis;

namespace Repository.Manager.Admin;

public class AdminRepository:GenericRepository<Domain.Entities.Admin.Admin>,IAdminRepository
{
    
    public readonly ICacheRepository CacheRepository;
    public AdminRepository(ICacheRepository CacheRepository,ApplicationDbContext DbContext) : base(DbContext)
    {
        this.CacheRepository = CacheRepository;
    }

    public bool IsEmailExists(string Email)
    {
        
        return this.DbContext.Admins.Any(x => x.Email.Equals(Email));
        
    }

    public Domain.Entities.Admin.Admin GetByEmail(string Email)
    {


        return DbContext.Admins.First();

    }


    public bool Logout(string Token)
    {
        
        CacheRepository.RemoveData($"Token:{Token}");
        return true;
        
    }


    
    
}