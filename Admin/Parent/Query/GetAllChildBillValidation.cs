using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Parent.Query;
public class GetAllChildBillValidation: AbstractValidator<GetAllChildBillQuery>
{


    public GetAllChildBillValidation(ApplicationDbContext context){


        RuleFor(x=>x.ParentId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Parents.Any(x=>x.Id==id))
        .WithMessage("this parent is not exists in our data");

    }

}
