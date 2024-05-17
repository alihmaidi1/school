using Domain.Entities.Manager.Admin;
using Domain.Enum;
using Dto.Admin.Admin;
using Dto.Admin.Role;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
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

    public PageList<GetAllAdmin> GetAll(AdminSorting.OrderBy orderBy, int? pageNumber, int? pageSize, string? search)
    {
        var result = DbContext
            .Admins
            .Where(x=>x.Name.Contains(search??"")||x.Email.Contains(search??"")||x.Role.Name.Contains(search??""))
            .OrderBy(AdminSorting.SwitchOrdering(orderBy))
            .Select(AdminQuery.ToGetAllAdmin)
            .ToPagedList(pageNumber, pageSize);
        return result;
        
    }



    // public bool IsExists(Guid id)
    // {

    //     return DbContext.Admins.Any(x => x.Id.Equals(id));
    // }

    public GetAdminInfo GetInfo(Guid id)
    {

        return DbContext
            .Admins
            .Where(x=>x.Id.Equals(id))
            .Select(x=>new GetAdminInfo()
            {
                
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Status = x.Status,
                Image = x.Image,
                Hash = x.Hash,
                CreatedAt = x.DateCreated,
                Role = new GetAllRole()
                {
                    
                    Id = x.Role.Id,
                    Name = x.Role.Name,
                    Permissions = x.Role.Permissions,
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