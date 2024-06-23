using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Microsoft.AspNetCore.Http;
using Shared.Services.User;

namespace Parent.Student.Query.FinalResult;

public class GetParentFinalResultValidation:AbstractValidator<GetParentFinalResultQuery>
{

    public GetParentFinalResultValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull()
        .Must(ids=>context.Students.Any(x=>x.Id==ids&&x.ParentId==currentUserService.GetUserid()))
        .WithMessage("child is not correct");




    }

}
