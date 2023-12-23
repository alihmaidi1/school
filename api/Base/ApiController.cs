using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace schoolmanagment.Base;

public class ApiController: ControllerBase
{
    private IMediator mediatorinstance;
    protected  IMediator Mediator=> mediatorinstance??=HttpContext.RequestServices.GetService<IMediator>();

    
}