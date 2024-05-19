using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Student.Parent.Query.GetStudent;

public class GetAllParentStudentValidation: AbstractValidator<GetAllParentStudentQuery>
{

    public GetAllParentStudentValidation(ApplicationDbContext context){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Parents.Any(x=>x.Id==id))
        .WithMessage("this parent is not valid");


    }

}
