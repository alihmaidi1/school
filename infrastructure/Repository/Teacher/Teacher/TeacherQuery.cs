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
            StudentNumber=Teacher.TeacherSubjects.SelectMany(x=>x.SubjectYears.Where(x=>x.ClassYear.Status)).SelectMany(x=>x.StudentSubjects).Distinct().Count(),
            SubjectNumber=Teacher.TeacherSubjects.Count()            

        };


    
}