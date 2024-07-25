using Domain.Dto.Manager.Admin;
using Domain.Dto.Manager.Role;
using Domain.Enum.Ordering;
using infrastructure;
using infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

using Shared.Entity.EntityOperation;
namespace Repository.Manager.Admin;

public class AdminRepository:GenericRepository<Domain.Entities.Manager.Admin.Admin>,IAdminRepository
{
    
    public AdminRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }




    public bool Logout(string Token)
    {
        
        return true;
        
    }

    public PageList<GetAllAdminDto> GetAll( int? pageNumber, int? pageSize, string? search)
    {
        var result = DbContext
            .Admins
            .IgnoreQueryFilters()
            .OrderBy(x=>x.DateCreated)
            .Where(x=>x.Name!="SuperAdmin")
            .Where(x=>x.DateDeleted==null)
            .Where(x=>x.Name.Contains(search??"")||x.Email.Contains(search??"")||x.Role.Name.Contains(search??""))
            .Select(AdminQuery.ToGetAllAdmin)
            .ToPagedList(pageNumber, pageSize);
        return result;
        
    }



    // public bool IsExists(Guid id)
    // {

    //     return DbContext.Admins.Any(x => x.Id.Equals(id));
    // }

    public GetAdminInfoDto GetInfo(Guid id)
    {

        return DbContext
            .Admins
            .IgnoreQueryFilters()
            .Where(x=>x.DateDeleted==null)
            .Where(x=>x.Id.Equals(id))
            .Select(x=>new GetAdminInfoDto()
            {
                
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Status = x.Status,
                Image = x.Image,
                Hash = x.Hash,
                CreatedAt = x.DateCreated,
                Role = new GetAllRoleDto()
                {
                    
                    Id = x.Role.Id,
                    Name = x.Role.Name,
                    // Permissions = x.Role.Permissions,
                    CreatedAt = x.Role.DateCreated
                }
                
                
            })
            .First();

    }



    public bool Delete(Guid id)
    {

        DbContext.Admins.Where(x => x.Id.Equals(id)).ExecuteUpdate(setter=>setter.SetProperty(x=>x.DateDeleted,DateTime.Now));
        DbContext.SaveChanges();
        return true;
    }

    public List<Guid> GetIds(string Permission)
    {

        return DbContext.Admins.Include(x => x.Role)
            .Where(x=>x.Role.Permissions.Any(y=>y.Equals(Permission)))
            .Select(x=>x.Id)
            .ToList();

    }

}