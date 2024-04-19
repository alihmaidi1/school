using System.ComponentModel.DataAnnotations;
using Common.CQRS;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;

namespace Common.Feature.Image.Command.UploadSingle;

public class UploadImageCommand: ICommand
{
 
    
    [DataType(DataType.Upload)]
    public IFormFile Image { get; init; }

}