using Dto.Teacher.Warning;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Teacher.Warning;

public interface IWarningRepository:IgenericRepository<Domain.Entities.Teacher.Warning.Warning>
{

    public PageList<GetAllWarningResponse> GetAll(Guid? teacherId, int? pageNumber, int? pageSize);
 
    public PageList<GetAllWarningAdminResponse> GetAll(int? Date,Guid? teacherId, int? pageNumber, int? pageSize);
}