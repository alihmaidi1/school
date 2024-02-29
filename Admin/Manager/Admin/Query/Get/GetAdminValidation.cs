using Domain.Entities.Manager.Admin;
using FluentValidation;
using Repository.Manager.Admin;

namespace Admin.Manager.Admin.Query.Get;

public class GetAdminValidation:AbstractValidator<GetAdminQuery>
{


    public GetAdminValidation(IAdminRepository adminRepository)
    {


        RuleFor(x => x.id)
            .NotNull()
            .NotEmpty()
            .Must(x=>adminRepository.IsExists(new AdminID(x)))
            .WithMessage("this admin is not exists in our data");
    }
}