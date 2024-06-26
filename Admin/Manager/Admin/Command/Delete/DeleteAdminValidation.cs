using Domain.Entities.Manager.Admin;
using FluentValidation;
using infrastructure;
using Repository.Manager.Admin;

namespace Admin.Manager.Admin.Command.Delete;

public class DeleteAdminValidation:AbstractValidator<DeleteAdminCommand>
{
 
    public DeleteAdminValidation(ApplicationDbContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(id => context.Admins.Where(x=>x.DateDeleted==null).Any(x=>x.Id==id))
            .WithMessage("this admin is not exists in our data");
    }
}