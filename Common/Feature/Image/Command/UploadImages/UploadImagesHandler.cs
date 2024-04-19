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

namespace Common.Feature.Image.Command.UploadImages;

public class UploadImagesHandler :OperationResult,ICommandHandler<UploadImagesCommand>
{
    
    private readonly IMapper _mapper;
    private ApplicationDbContext _context;
    public UploadImagesHandler(IMapper mapper,ApplicationDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<JsonResult> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
    {
        var imagesResponse = await request.images.OptimizeMany();
        var images=imagesResponse.Select(x => _mapper.Map<Domain.Base.Entity.Image>(x)).ToList();
        _context.Images.AddRange(images);
        _context.SaveChanges();
        return Success(images,"images was uploaded successfully");
    }
}