using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Services.User;

namespace Teacher.Student.Query.GetStudentHaveSubject;

public class GetStudentHaveSubjectValidation: AbstractValidator<GetStudentHaveSubjectQuery>
{

    public GetStudentHaveSubjectValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.SubjectId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context
            .SubjectYears
            .AsNoTracking()
            .Where(x=>x.ClassYear.Status)
            .Where(x=>x.SubjectId==id)
            .Where(x=>x.TeacherId==currentUserService.GetUserid())
            .Any()
        )
        .WithMessage("this subject is not available for you now");

    }

}
