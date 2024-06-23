using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Parent.Student.Query.GetStudentMarks;
public class GetParentStudentMarksValidation: AbstractValidator<GetParentStudentMarksQuery>
{

    public GetParentStudentMarksValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull()
        .Must(ids=>context.Students.Any(x=>x.ParentId==currentUserService.GetUserid()&&x.Id==ids))
        .WithMessage("some child is not correct");



    }

}
