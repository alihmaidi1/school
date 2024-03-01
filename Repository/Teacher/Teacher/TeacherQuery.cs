using System.Linq.Expressions;
using Dto.Admin.Teacher;

namespace Repository.Teacher.Teacher;

public static class TeacherQuery
{
    
    public static Expression<Func<Domain.Entities.Teacher.Teacher.Teacher, GetAllTeacher>> ToGetAllTeacher = Teacher =>
        new GetAllTeacher()
        {
            Id = Teacher.Id.Value,
            Name = Teacher.Name,
            Email = Teacher.Email,
            Status = Teacher.status,
            Image = Teacher.Image,
            Resize = Teacher.Resize,
            Hash = Teacher.Hash
        };


    
}