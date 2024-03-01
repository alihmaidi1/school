using Domain.Entities.Teacher.Teacher;
using Dto.Admin.Teacher;
using infrutructure;
using Repository.Base;
using Shared.Entity.EntityOperation;
using Shared.Repository;

namespace Repository.Teacher.Teacher;

public class TeacherRepository:GenericRepository<Domain.Entities.Teacher.Teacher.Teacher>,ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public PageList<GetAllTeacher> GetAllTecher(string? OrderBy, int? pageNumber, int? pageSize)
    {

        var Result = DbContext.Teachers
            .Sort<TeacherID,Domain.Entities.Teacher.Teacher.Teacher>(OrderBy, TeacherSorting.switchOrdering)
            .Select(TeacherQuery.ToGetAllTeacher)
            .ToPagedList(pageNumber,pageSize);


        return Result;


    }

    public bool IsExists(string Email)
    {
        return DbContext.Teachers.Any(x => x.Email.Equals(Email));
    }

    public bool IsExists(TeacherID ID)
    {

        return DbContext.Teachers.Any(x=>x.Id.Equals(ID));
    }

    public bool IsUnique(TeacherID id, string Email)
    {

        return DbContext.Teachers.Any(x => x.Email.Equals(Email) && !x.Id.Equals(id));
    }

    public Domain.Entities.Teacher.Teacher.Teacher Get(TeacherID id)
    {

        return DbContext.Teachers.FirstOrDefault(x=>x.Id.Equals(id));
    }



}