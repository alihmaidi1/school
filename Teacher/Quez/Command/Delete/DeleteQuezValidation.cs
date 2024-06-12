using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuezEntity=Domain.Entities.Quez;
using FluentValidation;
using infrastructure;
using LinqKit;
using Shared.Services.User;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Teacher.Quez.Command.Delete;

public class DeleteQuezValidation: AbstractValidator<DeleteQuezCommand>
{

    public DeleteQuezValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(
            (QuezEntity.Quez.IsNotStarted().Or(QuezEntity.Quez.IsFinished()))
            .And(QuezEntity.Quez.IsBelongForId(currentUserService.UserId!.Value))
            
            
            ))
        .WithMessage("you can not delete this quez because it is active");
    }

}
