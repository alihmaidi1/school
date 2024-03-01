using System.Data.Common;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Domain.Entities.Teacher.Vacation;
using Dto.Teacher.Vacation;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Teacher.Vacation;

public interface IVacationRepository:IgenericRepository<Domain.Entities.Teacher.Vacation.Vacation>
{


    public bool IsExists(VacationID vacationId);


    public bool ChangeStatus(VacationID vacationId,AdminID adminId, bool Status);


    public PageList<GetAllVacationResponse> GetAll(bool? Status,Guid? teacherId, int? pageNumber, int? pageSize);

}