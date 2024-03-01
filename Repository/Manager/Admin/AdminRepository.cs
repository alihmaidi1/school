using Domain.Entities.Manager.Admin;
using Domain.Enum;
using Dto.Admin.Admin;
using Dto.Admin.Role;
using infrutructure;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Shared.Entity.EntityOperation;
using Shared.Redis;
using Shared.Repository;

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
        
        return DbContext.Admins.IgnoreQueryFilters().Any(x => x.Email.Equals(Email));
        
    }

    public Domain.Entities.Admin.Admin GetByEmail(string Email)
    {


        return DbContext.Admins.IgnoreQueryFilters().First(x=>x.Email.Equals(Email));

    }


    public bool Logout(string Token)
    {
        
        CacheRepository.RemoveData($"Token:{Token}");
        return true;
        
    }



    public PageList<GetAllAdmin> GetAlladmin(string? OrderBy, int? pageNumber, int? pageSize)
    {

        var Result = DbContext.Admins
            .Where(x => !x.Name.Equals(RoleEnum.SuperAdmin.ToString()))
            .Sort<AdminID, Domain.Entities.Admin.Admin>(OrderBy, AdminSorting.switchOrdering)
            .Select(AdminQuery.ToGetAllAdmin)
            .ToPagedList(pageNumber, pageSize);
        return Result;
        
    }

    public bool IsExists(AdminID id)
    {

        return DbContext.Admins.Any(x => x.Id.Equals(id));
    }

    public GetAdminInfo GetInfo(AdminID id)
    {

        return DbContext
            .Admins
            .Include(x=>x.Role)
            .Where(x=>x.Id.Equals(id))
            .Select(x=>new GetAdminInfo()
            {
                
                Id = x.Id.Value,
                Name = x.Name,
                Email = x.Email,
                Status = x.Status,
                Image = x.Image,
                Hash = x.Hash,
                Resize = x.Resize,
                CreatedAt = x.DateCreated,
                Role = new GetAllRole()
                {
                    
                    Id = x.Role.Id.Value,
                    Name = x.Role.Name,
                    Permissions = x.Role.Permissions,
                    CreatedAt = x.Role.DateCreated
                }
                
                
            })
            .First();

    }


    public bool IsEmailExists(string Email, AdminID id)
    {

        return DbContext.Admins.Any(x => x.Email.Equals(Email) && !x.Id.Equals(id));


    }


    public bool Delete(AdminID id)
    {

        DbContext.Admins.Where(x => x.Id.Equals(id)).ExecuteUpdate(setter=>setter.SetProperty(x=>x.DateDeleted,DateTime.Now));
        DbContext.SaveChanges();
        return true;
    }

    public List<AdminID> GetIds(string Permission)
    {

        return DbContext.Admins.Include(x => x.Role)
            .Where(x=>x.Role.Permissions.Any(y=>y.Equals(Permission)))
            .Select(x=>x.Id)
            .ToList();

    }

}