using System.Linq.Expressions;
using Dto.Admin.Teacher;

namespace Repository.Teacher.Teacher;

public static class TeacherQuery
{
    
    public static Expression<Func<Domain.Entities.Teacher.Teacher.Teacher, GetAllTeacher>> ToGetAllTeacher = Teacher =>
        new GetAllTeacher()
        {
            Id = Teacher.Id,
            Name = Teacher.Name,
            Email = Teacher.Email,
            Image = Teacher.Image,
            Hash = Teacher.Hash,
            SubjectNumber=Teacher.SubjectYears.Count(x=>x.Year.Date.Year==DateTime.Now.Year)
        };


    
}