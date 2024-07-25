using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        

        if(request.Image is not null){

            var image = _context.Images.First(x => x.Id == request.Image);

            await _context.Parents.Where(x=>x.Id==request.Id)
            .ExecuteUpdateAsync(setter=>
            setter.SetProperty(x=>x.Image,image.Url.GetNewPath(FolderName.Parent).httpPath)
            .SetProperty(x=>x.Hash,image.Hash)            
            .SetProperty(x=>x.Name,request.Name)
            .SetProperty(x=>x.Email,request.Email)            
            ,cancellationToken);            
            image.Url.MoveFile(image.Url.GetNewPath(FolderName.Parent).localPath);

        }else{

            await _context.Parents.Where(x=>x.Id==request.Id)
            .ExecuteUpdateAsync(setter=>
            setter   
            .SetProperty(x=>x.Name,request.Name)
            .SetProperty(x=>x.Email,request.Email)            
            ,cancellationToken);            


        }
        return Success("Parent was created successfully");

        
    }
}
