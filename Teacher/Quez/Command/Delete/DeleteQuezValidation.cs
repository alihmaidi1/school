using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Teacher.Quez.Command.Delete;

public class DeleteQuezValidation: AbstractValidator<DeleteQuezCommand>
{

    public DeleteQuezValidation(ApplicationDbContext context){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.IsPending()||x.IsFinished()))
        .WithMessage("you cannt delete this quez because it is active");

    }

}
