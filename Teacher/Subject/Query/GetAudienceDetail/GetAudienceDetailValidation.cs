using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Subject.Query.GetAudienceDetail;
public class GetAudienceDetailValidation: AbstractValidator<GetAudienceDetailQuery>
{

    public GetAudienceDetailValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        // RuleFor(x=>x.Date)
        // .NotEmpty()
        // .NotNull();
        // RuleFor(x=>x.SubjectId)
        // .NotEmpty()
        // .Null()
        // .Must((request,id)=>context.SubjectYears.Any(x=>x.SubjectId==id&&x.TeacherId==currentUserService.UserId&&x.Audiences.Any(y=>y.Date==request.Date)))
        // .WithMessage("this subject does not have any leson in this date");

    }

}
