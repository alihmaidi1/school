using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Parent.Student.Command.GiveReasonOfAudience;

public class GiveReasonOfAudienceValidation: AbstractValidator<GiveReasonOfAudienceCommand>
{

    public GiveReasonOfAudienceValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.Reason)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Audiences.Any(x=>x.Id==id&&x.Student.ParentId==currentUserService.GetUserid()))
        .WithMessage("this audience is not correct");


        RuleFor(x=>x.ImageId)
        .Must(id=>context.Images.Any(x=>x.Id==id))
        .When(x=>x.ImageId!=null);

    }

}
