using Domain.Entities.Teacher.Teacher;
using Dto.Admin.Teacher;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Teacher.Teacher;

public interface ITeacherRepository:IGenericRepository<Domain.Entities.Teacher.Teacher.Teacher>
{
    
    public PageList<GetAllTeacher> GetAllTecher( int? pageNumber, int? pageSize,string? Search);


    // public bool IsExists(string Email);


    // public bool IsExists(Guid ID);

    // public bool IsUnique(Guid id ,string Email);

    public Domain.Entities.Teacher.Teacher.Teacher Get(Guid id);

}