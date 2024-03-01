using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Domain.Entities.Teacher.Vacation;
using Dto.Teacher.Vacation;
using infrutructure;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Shared.Entity.EntityOperation;
namespace Repository.Teacher.Vacation;
public class VacationRepository:GenericRepository<Domain.Entities.Teacher.Vacation.Vacation>,IVacationRepository
{
    public VacationRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(VacationID vacationId)
    {
        return DbContext.Vacations.Any(x => x.Id.Equals(vacationId));
    }

    public bool ChangeStatus(VacationID vacationId,AdminID adminId, bool Status)
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
            .WhereWhenNotNull(teacherId!=null,x=>x.TeacherId==new TeacherID((Guid)teacherId))
            .WhereWhenNotNull(Status!=null,x=>x.Status==Status)
            .Select(x=>new GetAllVacationResponse()
            {
                Id = x.Id.Value,
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