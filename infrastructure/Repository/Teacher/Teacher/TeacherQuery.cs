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
            SubjectIds=Teacher.TeacherSubjects.Select(x=>x.SubjectId).ToList(),
            Hash = Teacher.Hash,
            StudentNumber=Teacher.SubjectYears.Where(x=>x.DateDeleted==null).Where(x=>x.ClassYear.Status).SelectMany(x=>x.StudentSubjects.Where(x=>x.DateDeleted==null)).Distinct().Count(),
            SubjectNumber=Teacher.TeacherSubjects.Where(x=>x.DateDeleted==null).Count()            

        };


    
}