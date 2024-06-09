using Bogus;
using Domain.Entities.Teacher.Teacher;
using FluentValidation;
using Repository.Teacher.Teacher;

namespace Admin.Teacher.Vacation.Query.GetAll;

public class GetVacationValidation:AbstractValidator<GetVacationQuery>
{

    public GetVacationValidation()
    {




    }
    
}