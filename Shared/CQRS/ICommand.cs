using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Shared.CQRS;

public interface ICommand : IRequest<JsonResult>
{
}
//
//
// public interface ICommand<TResponse> : IRequest<JsonResult>
// {
//     
//     
// }