using System.Linq.Expressions;
using Domain.Dto.Teacher;
using Dto.Admin.Teacher;

namespace Repository.Teacher.Teacher;

public static class TeacherQuery
{
    
    public static Expression<Func<Domain.Entities.Teacher.Teacher.Teacher, GetAllTeacherDto>> ToGetAllTeacher = Teacher =>
        new GetAllTeacherDto()
        {
            Id = Teacher.Id,
            Name = Teacher.Name,
            Email = Teacher.Email,
            Image = Teacher.Image,
            Hash = Teacher.Hash,
            Status=Teacher.Status,
            Subject=Teacher.Subject.Name,
            StudentNumber=Teacher.SubjectYears.SelectMany(x=>x.StudentSubjects).Select(x=>x.StudentId).Distinct().Count()            

        };


    
}