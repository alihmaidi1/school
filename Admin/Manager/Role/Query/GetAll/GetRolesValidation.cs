using FluentValidation;
using Repository.Manager.Role;
using Shared.Rule;

namespace Admin.Manager.Role.Query.GetAll;

public class GetRolesValidation:AbstractValidator<GetRolesQuery>
{
    
    public GetRolesValidation()
    {
    }
}