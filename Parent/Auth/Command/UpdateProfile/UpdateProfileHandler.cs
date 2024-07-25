using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.Helper;
using Shared.OperationResult;
using Shared.Services.User;

namespace Parent.Auth.Command.UpdateProfile;
public class UpdateProfileHandler : OperationResult,ICommandHandler<UpdateProfileCommand>
{

    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;
    public UpdateProfileHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {

        var Parent=_context.Parents.First(x=>x.Id==_currentUserService.GetUserid());
        Parent.Name=request.Name;
        Parent.Email=request.Email;
        if(request.Password is not null){

            Parent.Password=PasswordHelper.HashPassword(request.Password);

        }
        await _context.SaveChangesAsync(cancellationToken);
        return Success("profile was updated successfully"); 

    }
}
