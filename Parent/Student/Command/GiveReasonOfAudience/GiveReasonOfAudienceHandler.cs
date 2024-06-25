using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Constant;
using Shared.CQRS;
using Shared.File;
using Shared.OperationResult;

namespace Parent.Student.Command.GiveReasonOfAudience;

public class GiveReasonOfAudienceHandler : OperationResult,ICommandHandler<GiveReasonOfAudienceCommand>
{

    private ApplicationDbContext _context;
    
    public GiveReasonOfAudienceHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GiveReasonOfAudienceCommand request, CancellationToken cancellationToken)
    {

        if(request.ImageId is  null){

            await _context
            .Audiences
            .Where(x=>x.Id==request.Id)
            .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Reason,request.Reason),cancellationToken);
        
            
        }else{

            
            var image=_context.Images.First(x=>x.Id==request.ImageId);        
            await _context
            .Audiences
            .Where(x=>x.Id==request.Id)
            .ExecuteUpdateAsync(setter=>
            setter.SetProperty(x=>x.Reason,request.Reason)
            .SetProperty(x=>x.Image,image.Url.GetNewPath(FolderName.Audience).httpPath)
            .SetProperty(x=>x.Hash,image.Hash)
            ,cancellationToken);
            image.Url.MoveFile(image.Url.GetNewPath(FolderName.Audience).localPath);      

        }

        
        return Success("gived successfully");
    }
}
