using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Quez.Query.GetAll;

public class GetAllTeacherQuezValidation: AbstractValidator<GetAllTeacherQuezQuery>
{

    public GetAllTeacherQuezValidation(ICurrentUserService currentUserService,ApplicationDbContext context){

        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this year is not valid");
    }

}
