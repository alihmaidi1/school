using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Constant;
using Shared.CQRS;
using Shared.File;
using Shared.Helper;
using Shared.OperationResult;
using Shared.test.DataBases.Upsert;

namespace Admin.Student.Parent.Command.Update;

public class UpdateParentHandler :OperationResult , ICommandHandler<UpdateParentCommand>
{

    private ApplicationDbContext _context;

    public UpdateParentHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(UpdateParentCommand request, CancellationToken cancellationToken)
    {

        
        var Parent = new Domain.Entities.Student.Parent.Parent()
        {
        
            Id=request.Id,
            Name = request.Name,
            Email = request.Email,
            Password = PasswordHelper.HashPassword(request.Password),
            
        
        };

        Parent.SendEmail("Update Parent Info",$"this this your password {request.Password}");

        if(request.Image is not null){
            
            var image = _context.Images.First(x => x.Id == request.Image);
            Parent.Image = image.Url.GetNewPath(FolderName.Parent).httpPath;
            Parent.Hash=image.Hash;
            _context.Parents.Update(Parent);
            _context.SaveChanges();
            image.Url.MoveFile(image.Url.GetNewPath(FolderName.Parent).localPath);


        }else{

            _context.Parents.Update(Parent);
            _context.SaveChanges();
        }
        return Success("Parent was created successfully");

        
    }
}
