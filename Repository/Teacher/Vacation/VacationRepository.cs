
using Dto.Teacher.Vacation;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Shared.Entity.EntityOperation;
namespace Repository.Teacher.Vacation;
public class VacationRepository:GenericRepository<Domain.Entities.Teacher.Vacation.Vacation>,IVacationRepository
{
    public VacationRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(Guid vacationId)
    {
        return DbContext.Vacations.Any(x => x.Id.Equals(vacationId));
    }

    public bool ChangeStatus(Guid vacationId,Guid adminId, bool Status)
    {


         DbContext.Vacations.Where(x => x.Id.Equals(vacationId))
            .ExecuteUpdate(setter => setter.SetProperty(x => x.Status, Status));
         DbContext.SaveChanges();
         return true;

    }


    public PageList<GetAllVacationResponse> GetAll(bool? Status, Guid? teacherId, int? pageNumber, int? pageSize)
    {

        var Result = DbContext
            .Vacations
            .Include(x => x.Admin)
            .Include(x => x.Teacher)
            .WhereWhenNotNull(teacherId!=null,x=>x.TeacherId==(Guid)teacherId)
            .WhereWhenNotNull(Status!=null,x=>x.Status==Status)
            .Select(x=>new GetAllVacationResponse()
            {
                Id = x.Id,
                Admin = x.Admin!.Name,
                Teacher = x.Teacher.Name,
                Status = x.Status,
                Reason = x.Reason,
                Year = x.Date
            })
            .ToPagedList(pageNumber,pageSize);
        return Result;
        
    }

}