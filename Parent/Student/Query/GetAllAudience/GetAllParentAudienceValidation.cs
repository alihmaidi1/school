using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Parent.Student.Query.GetAllAudience;

public class GetAllParentAudienceValidation: AbstractValidator<GetAllParentAudienceQuery>
{

    public GetAllParentAudienceValidation(ApplicationDbContext context,ICurrentUserService currentUserService){



        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull()
        .Must(ids=>context.Students.Any(x=>x.ParentId==currentUserService.GetUserid()&&x.Id==ids))        
        .WithMessage("child is not correct");




    }

}
