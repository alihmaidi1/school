using Domain.Entities.Teacher.Teacher;
using Dto.Teacher.Warning;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Teacher.Warning;

public class WarningRepository:GenericRepository<Domain.Entities.Teacher.Warning.Warning>,IWarningRepository
{
    
    public WarningRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public PageList<GetAllWarningResponse> GetAll(Guid? teacherId, int? pageNumber, int? pageSize)
    {
     
        return DbContext
            .Warnings
            .Where(x=>x.TeacherId.Equals((Guid)teacherId))
            .Include(x=>x.Admin)
            .Select(x=>new GetAllWarningResponse()
            {
                 
                Id = x.Id,
                ManagerName = x.Admin.Name,
                Reason = x.Reason,
                Date = x.Date
                
            })
            .ToPagedList(pageNumber,pageSize);
    }

    public PageList<GetAllWarningAdminResponse> GetAll(int? Date, Guid? teacherId, int? pageNumber, int? pageSize)
    {
        
        return DbContext
            .Warnings
            .WhereWhenNotNull(teacherId!=null,x=>x.TeacherId.Equals((Guid)teacherId))
            .WhereWhenNotNull(Date!=null,x=>x.Date==Date)
            .Include(x=>x.Admin)
            .Include(x=>x.Teacher)
            .Select(x=>new GetAllWarningAdminResponse()
            {
                 
                Id = x.Id,
                ManagerName = x.Admin.Name,
                Reason = x.Reason,
                Date = x.Date,
                Teacher = x.Teacher.Name
            })
            .ToPagedList(pageNumber,pageSize);
    }


}