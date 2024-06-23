using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Parent.Student.Query.GetBill;

public class GetParentBillValidation: AbstractValidator<GetParentBillQuery>
{

    public GetParentBillValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull()
        .Must(ids=>context.Students.Any(x=>x.ParentId==currentUserService.GetUserid()&&x.Id==ids))        
        .WithMessage("child is not correct");




    }

}
