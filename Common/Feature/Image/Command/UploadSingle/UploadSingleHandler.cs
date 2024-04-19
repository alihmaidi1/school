using AutoMapper;
using Common.CQRS;
using infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.Extension;
using Shared.File;
using Shared.OperationResult;

namespace Common.Feature.Image.Command.UploadSingle;

public class UploadSingleHandler : OperationResult,ICommandHandler<UploadImageCommand>
{
    
    private readonly IMapper _mapper;
    private ApplicationDbContext _context;
    public UploadSingleHandler(IMapper mapper,ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;

    }
    public async Task<JsonResult> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        var image =request.Image.OptimizeFile();
        _context.Images.Add(_mapper.Map<Domain.Base.Entity.Image>(image));
        _context.SaveChanges();
        return Success(image,"The Image Was Uploaded Successfully");
    }
}