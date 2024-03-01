using Domain.Entities.Teacher.Teacher;
using Dto.Admin.Teacher;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Teacher.Teacher;

public interface ITeacherRepository:IgenericRepository<Domain.Entities.Teacher.Teacher.Teacher>
{
    
    public PageList<GetAllTeacher> GetAllTecher(string? OrderBy, int? pageNumber, int? pageSize);


    public bool IsExists(string Email);


    public bool IsExists(TeacherID ID);

    public bool IsUnique(TeacherID id ,string Email);

    public Domain.Entities.Teacher.Teacher.Teacher Get(TeacherID id);

}