using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace schoolManagement.Base;

public class ApiController: ControllerBase
{
    private IMediator mediatorinstance;
    protected  IMediator Mediator=> mediatorinstance??=HttpContext.RequestServices.GetService<IMediator>();

    
}