using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Shared.CQRS;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, JsonResult> where TCommand : ICommand
{
}