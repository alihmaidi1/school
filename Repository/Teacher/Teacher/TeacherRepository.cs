using Domain.Entities.Teacher.Teacher;
using Dto.Admin.Teacher;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Shared.Entity.EntityOperation;
using Shared.Repository;

namespace Repository.Teacher.Teacher;

public class TeacherRepository:GenericRepository<Domain.Entities.Teacher.Teacher.Teacher>,ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public PageList<GetAllTeacher> GetAllTecher( int? pageNumber, int? pageSize,string? Search)
    {

        var Result = DbContext
            .Teachers
            .Include(x=>x.SubjectYears)
            .ThenInclude(x=>x.Year)
            .Where(x=>x.Name.Contains(Search??""))
            .Where(x=>x.Email.Contains(Search??""))            
            .Select(TeacherQuery.ToGetAllTeacher)
            .ToPagedList(pageNumber,pageSize);


        return Result;


    }

    // public bool IsExists(string Email)
    // {
    //     return DbContext.Teachers.Any(x => x.Email.Equals(Email));
    // }

    // public bool IsExists(Guid ID)
    // {

    //     return DbContext.Teachers.Any(x=>x.Id.Equals(ID));
    // }

    // public bool IsUnique(Guid id, string Email)
    // {

    //     return DbContext.Teachers.Any(x => x.Email.Equals(Email) && !x.Id.Equals(id));
    // }

    public Domain.Entities.Teacher.Teacher.Teacher Get(Guid id)
    {

        return DbContext.Teachers.FirstOrDefault(x=>x.Id.Equals(id));
    }



}