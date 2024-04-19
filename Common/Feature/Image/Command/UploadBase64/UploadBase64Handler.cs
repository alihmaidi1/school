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

namespace Common.Feature.Image.Command.UploadBase64;

public class UploadBase64Handler : OperationResult,ICommandHandler<UploadBase64Command>
{
    private readonly IMapper _mapper;

    private ApplicationDbContext _context;
    public UploadBase64Handler(IMapper mapper,ApplicationDbContext context)
    {
        _context = context;
        _mapper = mapper;


    }
    
    public async Task<JsonResult> Handle(UploadBase64Command request, CancellationToken cancellationToken)
    {
        var image = request.Image.OptimizeBase64();
        _context.Images.Add(_mapper.Map<Domain.Base.Entity.Image>(image));
        _context.SaveChanges();
        return Success(image,"The Image Was Uploaded Successfully");

    }
}