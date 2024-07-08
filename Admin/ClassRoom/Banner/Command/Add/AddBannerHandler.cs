using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Constant;
using Shared.CQRS;
using Shared.File;
using Shared.OperationResult;

namespace Admin.ClassRoom.Banner.Command.Add;
public class AddBannerHandler : OperationResult,ICommandHandler<AddBannerCommand>
{

    private ApplicationDbContext _context;
    public AddBannerHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(AddBannerCommand request, CancellationToken cancellationToken)
    {

        var Image=_context.Images.First(x=>x.Id==request.Image);

        var Banner=new Domain.Entities.ClassRoom.Banner{

            Name=request.Name,
            StartAt=request.StartAt,
            EndAt=request.EndAt,
            Url=request.Url,
            Image=Image.Url.GetNewPath(FolderName.Banner).httpPath


        };
        _context.Banners.Add(Banner);
        await _context.SaveChangesAsync(cancellationToken);
        Image.Url.MoveFile(Image.Url.GetNewPath(FolderName.Banner).localPath);
        return Created(true,"Created Successfully");
    }
}
