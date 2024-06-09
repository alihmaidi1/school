using Domain.Entities.Manager.Admin;
using FluentValidation;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Manager.Admin;

namespace Admin.Manager.Admin.Query.Get;

public class GetAdminValidation:AbstractValidator<GetAdminQuery>
{


    public GetAdminValidation(ApplicationDbContext context)
    {


        RuleFor(x => x.id)
            .NotNull()
            .NotEmpty()
            .Must(id=>context.Admins.IgnoreQueryFilters().Where(x=>x.DateDeleted==null).Any(x=>x.Id==id))
            .WithMessage("this admin is not exists in our data");
    }
}