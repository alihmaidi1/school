using Bogus;
using Domain.Entities.Teacher.Teacher;
using FluentValidation;
using Repository.Teacher.Teacher;

namespace Admin.Teacher.Vacation.Query.GetAll;

public class GetVacationValidation:AbstractValidator<GetVacationQuery>
{

    public GetVacationValidation(ITeacherRepository teacherRepository)
    {

        RuleFor(x => x.TeacherId)
            .Must(x => teacherRepository.IsExists(new TeacherID((Guid)x)))
            .When(x => x.TeacherId != null);



    }
    
}