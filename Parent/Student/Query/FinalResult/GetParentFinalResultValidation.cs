using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Parent.Student.Query.FinalResult;

public class GetParentFinalResultValidation:AbstractValidator<GetParentFinalResultQuery>
{

    public GetParentFinalResultValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        
        RuleFor(x=>x.Childs)
        .Must(ids=>context.Students.Count(x=>x.ParentId==currentUserService.UserId&&ids!.Distinct().Contains(x.Id))==ids!.Distinct().Count())
        .When(request=>request.Childs?.Any()??false)
        .WithMessage("some child is not correct");




    }

}
